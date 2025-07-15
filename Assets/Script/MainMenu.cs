using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainMenu()
    {
        if (GameManager.Instance.isGameOver)
        {
            Time.timeScale = 1.0f;
            GameManager.Instance.isGameOver = false;
            SceneManager.LoadScene("StartScreen");
        }

    }
}
