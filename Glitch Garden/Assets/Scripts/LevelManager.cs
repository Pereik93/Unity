using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;    

	public void Start(){
        if (autoLoadNextLevelAfter == 0)
        {
            Debug.Log("Level auto load disabled");
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
		
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("Quit game requested");
		Application.Quit();
	}

	
}
