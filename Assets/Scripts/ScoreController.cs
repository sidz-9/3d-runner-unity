using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    public int score;
    public int coinScore;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        coinScore = 0;
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("CoinScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore() {
        score++;
    }

    public void IncrementCoinScore() {
        coinScore++;
    }

    public void StopScore() {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("CoinScore", coinScore);

        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore")) 
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
