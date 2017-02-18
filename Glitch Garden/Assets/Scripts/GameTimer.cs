using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    private float levelSeconds = 100f;
    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private GameObject winLabel;

    private bool isEndOfLevel = false;
	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        FindYouWin();
        winLabel.SetActive(false);
	}

    void FindYouWin()
    {

        winLabel = GameObject.Find("You Win");

        if (!winLabel)
        {
            Debug.LogWarning("Create You Win object");
        }
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = 1- (Time.timeSinceLevelLoad / levelSeconds);

        if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }
	}

    void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach(GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
