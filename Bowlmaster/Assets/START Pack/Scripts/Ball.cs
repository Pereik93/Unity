using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody rigidBody;
    public Vector3 launchVelocity;
    public Vector3 initialPosition;
    private AudioSource audioSource;
    public bool inPlay = false;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        initialPosition = transform.position;
	}
	
    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }

}
