using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string HIGH_SCORE_KEY = "high_score";
    const string CURRENT_SCORE_KEY = "current_score";


    public static void SetHighScore( int highScore)
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
    }

    public static void SetCurrentScore(int score)
    {
        PlayerPrefs.SetInt(CURRENT_SCORE_KEY, score);
    }

    public static int GetCurrentScore()
    {
        return PlayerPrefs.GetInt(CURRENT_SCORE_KEY);
    }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
       return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= Application.levelCount - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        } else
        {
            Debug.Log("Unlocked Level out of range");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);
        if (level <= Application.levelCount - 1)
        {
            // return bool
            return isLevelUnlocked;
        }
        else
        {
            Debug.Log("Level out of build order");
            return false;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if(difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        } else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
