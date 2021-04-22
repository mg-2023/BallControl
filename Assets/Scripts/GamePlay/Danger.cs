using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
	Ball playerBall;
	
	// Start is called before the first frame update
	void Start()
	{
		playerBall = FindObjectOfType<Ball>();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.CompareTag("Player"))
		{
			playerBall.transform.position = new Vector3(-14f + 32f*(playerBall.CurStage-1), -6f, 0f);
			
			Ball.ballRB.velocity = new Vector2(0f, 0f);
			Ball.ballSR.color = new Color(1f, 1f, 0f, 1f);

			playerBall.DashEnabled = false;
			playerBall.JumpEnabled = false;
		}
	}

	/*
	// Update is called once per frame
	void Update()
	{
		
	}
	*/
}
