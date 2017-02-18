using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health;
    public int scoreValue = 25;

    private ScoreKeeper scoreKeeper;


    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
    
    public void DealDamage(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            // optionally trigger animation
            DestroyObject();      
        }
    }

  

    public void DestroyObject()
    {
        Destroy(gameObject);
        scoreKeeper.AddScore(scoreValue);
    }
}
