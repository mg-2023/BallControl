using System;
using UnityEngine;

public class StageTrans : MonoBehaviour
{
	Ball playerBall;
	
	public GameObject ball;
	public GameObject cam;
	
	// Start is called before the first frame update
	void Start()
	{
		playerBall = FindObjectOfType<Ball>();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		playerBall.CurStage++;
        // TODO: uncomment these two lines when finished designing all the stages
		/*
		if(playerBall.CurStage > Intro.Maximum)
			Intro.Maximum++;
		*/

		ball.transform.position = new Vector3(-14f + 32f*(playerBall.CurStage-1), -6f, 0f);
		Ball.ballRB.velocity = new Vector2(0f, 0f);

		cam.transform.position = new Vector3(32f*(playerBall.CurStage-1), 0f, -1f);

		// control jump state when stage transition
		playerBall.OnGround = false;
		playerBall.JumpEnabled = false;
		playerBall.DashEnabled = false;
	}

	/*
	// Update is called once per frame
	void Update()
	{
		
	}
	*/
}
