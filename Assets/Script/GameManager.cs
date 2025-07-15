    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int CollectedGems;
    public Text txtLiveCountText;
    public int Lives { get; set; }
    public Text txtCountGemsText;
    private int Gem = 0;
    public GameObject GameOver;
    public bool isGameOver = false;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            GameOver.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        CollectedGems = 0;
    }
    public void AddGem()
    {
        CollectedGems++;
        UpdateGemUI();
    }

    public void ResetGemCount()
    {
        CollectedGems = 0;
        UpdateGemUI();
    }

    public void AddLives()
    {
        Lives++;
        UpdateLivesUI();
    }

    private void UpdateGemUI()
    {
        if (txtCountGemsText != null)
            txtCountGemsText.text = CollectedGems.ToString();
    }

    private void UpdateLivesUI()
    {
        if (txtLiveCountText != null)
            txtLiveCountText.text = Lives.ToString();
    }
    public void VictoryScene()
    {
        GameOver.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0f;
    }
    public void ResetGameData()
    {
        // Đặt lại dữ liệu game về trạng thái ban đầu
        Lives = 1;
        CollectedGems = 0;
        UpdateGemUI();
        UpdateLivesUI();
        // TODO: Đặt lại các dữ liệu khác (vị trí, trạng thái nhân vật, v.v.)
    }

}
