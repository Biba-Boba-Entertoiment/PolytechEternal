using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    public TMP_Text levelScoreLabel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Slider healthBar;
    public AudioManager playerAudioManager;
    public HealthScript healthScript;
    public GameObject continueButton;

    public static int score = 0;
    public static bool gameOver;
    public static bool winLevel;
    public float timer = 0;
    public int maxScore;
    
    private int healthPoints;
    private int currentLevel;
    private bool isSoundPlayed = false;

    void Start()
    {
        gameOver = winLevel = false;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        maxScore = PlayerPrefs.GetInt("Record" + currentLevel);
        //healthScript = GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = levelScoreLabel.text = "Score: " + score;
        if (score > maxScore)
        PlayerPrefs.SetInt(("Record" + currentLevel), score);
        
        healthBar.value = healthScript.currentHealth;
        
        if (healthScript.isPlayerDead == true)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
        }

        // если расстояние до ближайшего врага нулевое(то бишь их больше нет)
        else if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0) 
        {
            if(Camera.main.GetComponent<Spawner>().currentCount == Camera.main.GetComponent<Spawner>().maxCount)
            {
                winPanel.SetActive(true);
                
                if(!isSoundPlayed)
                {
                    isSoundPlayed = true;
                    playerAudioManager.PlayWinSound();
                }
            }
            else continueButton.SetActive(true);

        }
    }

    public void Win()
    {
        winLevel = true;
        score = 0;
        timer += Time.deltaTime;
        if(timer > 5)
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevel == 3)
                SceneManager.LoadScene(0);

            if(PlayerPrefs.GetInt("ReachedLevel", 1) < nextLevel)
                PlayerPrefs.SetInt("ReachedLevel", nextLevel);

            SceneManager.LoadScene(nextLevel);
        }
    }
}
