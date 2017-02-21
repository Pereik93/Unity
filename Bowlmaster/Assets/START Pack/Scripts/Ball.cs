using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody rigidBody;
    public Vector3 launchVelocity;
    private AudioSource audioSource;
    public bool inPlay = false;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
	}
	
    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
	
}
