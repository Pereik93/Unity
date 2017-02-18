using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreKeeper : MonoBehaviour {

    private Text scoreText;
    public static int score = 0;
    public static int highScore = 0;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();
        score = PlayerPrefsManager.GetCurrentScore();
        highScore = PlayerPrefsManager.GetHighScore();
        scoreText.text = "Score: " + score.ToString();
    }


    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefsManager.SetCurrentScore(score);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefsManager.SetHighScore(highScore);
        }
    }

    public static void Reset()
    {
        score = 0;
    }
}
