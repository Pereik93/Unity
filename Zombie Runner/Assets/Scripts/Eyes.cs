using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

    private Camera eyes;
    private float defaulFOV = 70;
    

	// Use this for initialization
	void Start () {
        eyes = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Zoom"))
        {
            eyes.fieldOfView = Mathf.Lerp(eyes.fieldOfView, defaulFOV / 1.5f, Time.deltaTime * 3);
        } else
        {
            eyes.fieldOfView = defaulFOV;
        }
	}
}
