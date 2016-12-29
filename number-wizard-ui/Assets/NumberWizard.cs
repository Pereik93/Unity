using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max; 
	int min;
	int guess;
	int maxGuessesAllowed = 7;
	
	public Text text;
	
	void Start () {
		
       	StartGame();
       	
	}
	
	void StartGame(){
		max = 1000; 
		min = 1;
		NextGuess();
		
		max = max +1;
		}
		
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			GuessHigher();
		} else if(Input.GetKeyDown(KeyCode.DownArrow)){
			GuessLower();
		}
	}

	public void GuessHigher(){
		min = guess;
		NextGuess();
	}
	
	public void GuessLower(){
		max = guess;
		NextGuess();
	}
	
			
	void NextGuess(){
		guess = Random.Range (min, max);
		text.text = guess.ToString();
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if(maxGuessesAllowed <= 0){
		Application.LoadLevel("Win");
		}
	}
}
