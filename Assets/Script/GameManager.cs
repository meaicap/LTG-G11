using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int CollectedGems;
    public Text txtLiveCountText;
    public int Lives { get; set; }
    public Text txtCountGemsText;
    public GameObject GameOver; // Biến để tham chiếu đến màn hình game over
    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Kiểm tra xem GameOver có được gán không
            if (GameOver == null)
            {
                Debug.LogError("GameOver has not been assigned in the inspector!");
            }
            else
            {
                GameOver.SetActive(false); // Ẩn màn hình game over khi bắt đầu
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        CollectedGems = 0; // Đặt lại số gem khi chuyển sang cấp độ mới
    }

    public void AddGem()
    {
        CollectedGems++; // Tăng số gem đã thu thập
        UpdateGemUI();
    }

    public void ResetGemCount()
    {
        CollectedGems = 0; // Đặt lại số gem
        UpdateGemUI();
    }

    public void AddLives()
    {
        Lives++; // Tăng số mạng
        UpdateLivesUI();
    }

    private void UpdateGemUI()
    {
        if (txtCountGemsText != null)
            txtCountGemsText.text = CollectedGems.ToString(); // Cập nhật giao diện số gem
    }

    private void UpdateLivesUI()
    {
        if (txtLiveCountText != null)
            txtLiveCountText.text = Lives.ToString(); // Cập nhật giao diện số mạng
    }

    public void VictoryScene()
    {
        if (GameOver != null)
        {
            GameOver.SetActive(true); // Hiển thị màn hình game over
            isGameOver = true;
            Time.timeScale = 0f; // Dừng thời gian trong trò chơi
        }
    }

    public void ResetGameData()
    {
        // Đặt lại dữ liệu game về trạng thái ban đầu
        Lives = 1; // Số mạng ban đầu
        CollectedGems = 0; // Đặt lại số gem
        UpdateGemUI();
        UpdateLivesUI();
        // TODO: Đặt lại các dữ liệu khác (vị trí, trạng thái nhân vật, v.v.)
    }
}