using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthDisplay : MonoBehaviour {

    private Text lifeText;
    private int livesLeft;

    private LoseCollider loseCollider;
    // Use this for initialization
    void Start () {
        lifeText = GetComponent<Text>();
        loseCollider = GameObject.FindObjectOfType<LoseCollider>();
        livesLeft = loseCollider.life;
        UpdateDisplay();
        print("Hp: " + loseCollider.life);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        lifeText.text = ("Hp: " + loseCollider.life);
    }
}
