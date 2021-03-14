using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public GameObject gameOverPanel;
    public GameObject startUi;
    public GameObject gameOverImage;
    public Text scoreText;
    public Text coinScoreText;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelCoinScoreText;
    public Text highScoreText;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // scoreText.text = ScoreController.instance.score.ToString();
        coinScoreText.text = "COINS: " + ScoreController.instance.coinScore.ToString();
    }

    public void GameStart() {
        startUi.SetActive(false);
    }
    public void GameOver() {
        highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore").ToString("0") + "m";
        gameOverPanelScoreText.text = "Current Score: " + PlayerPrefs.GetFloat("Score").ToString("0") + "m";
        gameOverPanelCoinScoreText.text = "Coins: " + PlayerPrefs.GetInt("CoinScore");
        gameOverPanel.SetActive(true);
    }

    public void Replay() {
        Debug.Log("Replay button clicked!!");
        SceneManager.LoadScene("Level1");
    }

    public void Menu() {
        Debug.Log("Menu button clicked!!");
        SceneManager.LoadScene("Menu");
    }

    public void Quit() {
        Debug.Log("Game Quit in GameOverMenu!");
        Application.Quit();
    }
}
