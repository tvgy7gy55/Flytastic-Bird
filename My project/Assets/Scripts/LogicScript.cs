using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public SettingsMenu settingsMenu;
    public AudioSource coinCollectSound;
    public AudioSource highScoreCollectSound;
    private bool beetScore = true;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        coinCollectSound.Play();
       

        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = playerScore.ToString();
            if (beetScore)
            {
                highScoreCollectSound.Play();
                beetScore = false;
            }
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
