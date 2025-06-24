using UnityEngine;

public class reward : MonoBehaviour
{
    public int scoreValue = 10; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.instance.addScore(scoreValue);

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
