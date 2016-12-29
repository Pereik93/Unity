using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
	if(autoPlay == false){
		MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay(){
		float minPos = -7.17f;
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, minPos);
		// ---- Error ---- 
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minPos, 7.17f);		
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
		float minPos = -7.17f;
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, minPos);
		// ---- Error ---- 
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16) -8.0f;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, minPos, 7.17f);		
		this.transform.position = paddlePos;
	}
}
