using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {
    private int highScore;
    private int score;

    void Start()
    {
        highScore = PlayerPrefsManager.GetHighScore();
        score = PlayerPrefsManager.GetCurrentScore();
        updateHighScoreDisplay();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void updateHighScoreDisplay()
    {
        Text highScoreText = GetComponent<Text>();

        if (score < highScore)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        else
        {
            highScoreText.text = "High Score: " + score.ToString();
            PlayerPrefsManager.SetHighScore(ScoreKeeper.highScore);
        }
        ScoreKeeper.Reset();
    }
}
