using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiChuyenNhanVat : MonoBehaviour
{
    public float tocdo;
    private float traiPhai;
    private bool isfacingRight = true;
    public bool duocPhepNhay;
    private Animator animator;
    private Rigidbody2D rb;

    // Các biến liên quan đến nhảy
    public float lucNhayNhe = 5f;
    public float thoiGianNhay = 0.25f;
    public float lucNhayToiDa = 8f;
    private bool dangGiunPhimNhay;
    private float thoiGianGiunPhimNhay;

    // Các biến liên quan đến miễn sát thương
    private bool immuneToDamage = false;
    private float immuneDuration = 2f;
    private float lastHitTime = 0f;

    private SpriteRenderer spriteRenderer; // Component SpriteRenderer để thay đổi trạng thái nhấp nháy

    // Các biến liên quan đến mạng sống và gem
    public int gemsToExtraLife = 10;

    healthManager m_healthBar;

    void Start()
    {
        // Khởi tạo các component và biến cơ bản
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGameData();
        }
        else
        {
            Debug.LogError("GameManager.Instance is null!");
        }

        m_healthBar = FindObjectOfType<healthManager>();
        if (m_healthBar == null)
        {
            Debug.LogError("healthManager not found in scene!");
        }
    }

    void Update()
    {
        traiPhai = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(traiPhai * tocdo, rb.linearVelocity.y);
        flip();
        animator.SetFloat("move", Mathf.Abs(traiPhai));

        // Xử lý nhảy
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && duocPhepNhay)
        {
            dangGiunPhimNhay = true;
            thoiGianGiunPhimNhay = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            if (dangGiunPhimNhay)
            {
                float lucNhay = Mathf.Clamp(lucNhayToiDa * (Time.time - thoiGianGiunPhimNhay) / thoiGianNhay, 0f, lucNhayToiDa);
                rb.AddForce(Vector2.up * lucNhay, ForceMode2D.Impulse);
                dangGiunPhimNhay = false;
                AudioManager.Instance?.PlaySFX("Jump"); // An toàn với null
            }
        }

        // Nhấp nháy khi trong trạng thái miễn sát thương
        if (immuneToDamage)
        {
            float blinkSpeed = 0.1f; // Tốc độ nhấp nháy
            bool isVisible = Mathf.FloorToInt(Time.time / blinkSpeed) % 2 == 0;
            spriteRenderer.enabled = isVisible;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }

    void flip()
    {
        if (isfacingRight && traiPhai < 0 || !isfacingRight && traiPhai > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 kichThuoc = transform.localScale;
            kichThuoc.x = kichThuoc.x * -1;
            transform.localScale = kichThuoc;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float contactPointY = collision.contacts[0].point.y;
            float enemyTopY = collision.collider.bounds.max.y;

            // Kiểm tra va chạm từ phía trên để tiêu diệt quái
            if (contactPointY > enemyTopY - 0.1944841f)
            {
                KillEnemy(collision.gameObject);
                AudioManager.Instance?.PlaySFX("Kill");
            }
            else if (!CanTakeDamage())
            {
                return; // Đang trong thời gian miễn sát thương
            }
            else if (GameManager.Instance.CollectedGems > 0)
            {
                DropGems();
                GameManager.Instance.ResetGemCount();
                SetImmune(true);
                StartCoroutine(ImmuneDuration());
                m_healthBar?.takeDamage(25); // An toàn với null
            }
            else
            {
                SetImmune(true);
                StartCoroutine(ImmuneDuration());
                m_healthBar?.takeDamage(25); // An toàn với null
            }
        }
    }

    private void KillEnemy(GameObject enemy)
    {
        enemy.GetComponent<diChuyenQuai>()?.Die(); // An toàn với null
    }

    public void Die()
    {
        if (GameManager.Instance.Lives >= 1)
        {
            GameManager.Instance.Lives--;
            GameManager.Instance.AddLives(); // cập nhật UI
            SetImmune(true);
            StartCoroutine(ImmuneDuration());
            transform.position = new Vector3(-12.002f, 0.766f, -0.315f);
            if (m_healthBar != null)
            {
                m_healthBar.healthAmount = 100f;
                m_healthBar.healthBar.fillAmount = 1f;
            }
        }
        else
        {
            ResetGame();
            AudioManager.Instance?.PlaySFX("Death"); // An toàn với null
            m_healthBar.healthAmount = 100f;
            m_healthBar.healthBar.fillAmount = 1f;
            GameManager.Instance.ResetGemCount();
        }
    }

    private void DropGems()
    {
        GameManager.Instance.ResetGemCount(); // Khi va chạm với quái, gem sẽ biến mất
        // TODO: Có thể thực hiện hành động nào đó sau khi gem biến mất (nếu cần)
    }

    private IEnumerator ImmuneDuration()
    {
        yield return new WaitForSeconds(immuneDuration);
        SetImmune(false);
    }

    private bool CanTakeDamage()
    {
        return Time.time >= lastHitTime + immuneDuration;
    }

    private void SetImmune(bool immune)
    {
        immuneToDamage = immune;
        lastHitTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D hitboxkhac)
    {
        switch (hitboxkhac.gameObject.tag)
        {
            case "matDat":
                duocPhepNhay = true;
                break;
            case "Gem":
                GameManager.Instance.AddGem();
                AudioManager.Instance?.PlaySFX("Collect");

                if (GameManager.Instance.CollectedGems >= gemsToExtraLife)
                {
                    GameManager.Instance.ResetGemCount(); // reset lại đếm
                    GameManager.Instance.AddLives(); // tăng mạng và cập nhật UI
                }

                hitboxkhac.gameObject.SetActive(false);
                break;
            case "Finish":
                GameManager.Instance.VictoryScene();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D hitboxkhac)
    {
        if (hitboxkhac.gameObject.tag == "matDat")
        {
            duocPhepNhay = false;
        }
    }

    private void ResetGame()
    {
        // TODO: Thực hiện các hành động cần thiết để reset trạng thái trò chơi
        Vector3 startingPosition = new Vector3(-12.002f, 0.766f, -0.315f); // Điều chỉnh vị trí ban đầu tùy theo yêu cầu
        transform.position = startingPosition;
        if (m_healthBar != null)
        {
            m_healthBar.healthAmount = 100f;
            m_healthBar.healthBar.fillAmount = 1f;
        }
        GameManager.Instance.ResetGameData();
    }
}