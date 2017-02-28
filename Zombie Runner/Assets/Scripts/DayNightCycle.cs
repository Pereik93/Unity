using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    [Tooltip ("Numer of minutes per second")]
    public float minutesPerSecond;

    private int defualtPos = 60;
	
	// Update is called once per frame
	void Update () {
        float angleThisFrame = Time.deltaTime / 360 * minutesPerSecond;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
	}
}
