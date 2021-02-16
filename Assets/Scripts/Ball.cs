using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	bool onGround;
	
	public static int curStage = 1;
	public static bool dashEnabled;
	public static SpriteRenderer ballSR;
	public static Rigidbody2D ballRB;
		
	public float accel, maxSpeed, jumpStrength;
	
	// Start is called before the first frame update
	void Start()
	{
		onGround = false;

		ballRB = gameObject.GetComponent<Rigidbody2D>();
		ballSR = gameObject.GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag != "Dash")
		{
			onGround = true;
			if(ballRB.velocity.x > maxSpeed)
				ballRB.velocity = new Vector2(maxSpeed, ballRB.velocity.y);
			
			else if(ballRB.velocity.x < -maxSpeed)
				ballRB.velocity = new Vector2(-maxSpeed, ballRB.velocity.y);
		}
	}

	// Update is called once per frame
	void Update()
	{
		// player movement control
		if(Input.GetKeyDown(KeyCode.UpArrow) && onGround)
		{
			onGround = false;
			ballRB.velocity = new Vector2(ballRB.velocity.x, jumpStrength);
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(ballRB.velocity.x > -maxSpeed)
				ballRB.velocity -= new Vector2(accel, 0f);
		}
		
		else
		{
			if(ballRB.velocity.x < 0)
				ballRB.velocity += new Vector2(accel, 0f);
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(ballRB.velocity.x < maxSpeed)
				ballRB.velocity += new Vector2(accel, 0f);
		}
		
		else
		{
			if(ballRB.velocity.x > 0)
				ballRB.velocity -= new Vector2(accel, 0f);
		}
		
		// player dash control
		if(Input.GetKeyDown(KeyCode.Z) && dashEnabled)
		{
			if(ballRB.velocity.x > 0)
				ballRB.velocity = new Vector2(15f, 5f);
			
			else
				ballRB.velocity = new Vector2(-15f, 5f);
			
			ballSR.color = new Color(1f, 1f, 0f, 1f);
			dashEnabled = false;
		}
	}
}
