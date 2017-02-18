using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;    

	public void Start(){
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled, use a positive value to enable");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }

    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void LoadLevel(string name){
		if(name == "02 Level_01")
        {
            PlayerPrefsManager.SetCurrentScore(0);
        }
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("Quit game requested");
		Application.Quit();
	}

	
}
