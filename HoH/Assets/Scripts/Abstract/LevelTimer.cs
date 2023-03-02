using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    #region Functions
    [Header("Timer Length in Seconds")]
    [SerializeField] private float timerLength = 900.0f; // 15 minutes in seconds
    
    [Header("TextMeshPro")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI Lives;

    [Header("Canvas")]
    [SerializeField] private GameObject deathCanvas;

    [SerializeField] private float totalLives = 1;
    private float timer = 0.0f;
    #endregion

    void Start()
    {
        timer = timerLength;
        Lives.text = "Lives: " + totalLives;

        Time.timeScale = 1.0f;
        deathCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        LifeCount();
        Timer();
    }


    #region Functions
    private void Timer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60.0f);
            int seconds = Mathf.FloorToInt(timer % 60.0f);
            timerText.text = string.Format("Timer: " + "{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Time.timeScale = 0.0f;

            timerText.text = "You Died!";
            Lives.text = "Lives: 0";

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            deathCanvas.SetActive(true);
        }
    }

    private void LifeCount()
    {
        Lives.text = "Lives: " + totalLives;
    }


    public void LoadThisScene()
    {
        SceneManager.LoadScene("Level1Sewer");
        
    }
    #endregion
}