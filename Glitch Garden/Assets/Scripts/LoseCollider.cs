using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public int life = 10;
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        life--;
        if (life <= 0)
        {
            levelManager.LoadLevel("03a Win");
        }
    }
}
