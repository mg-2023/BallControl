using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	bool onGround;
	Rigidbody2D ball;
	public float accel, maxSpeed, jumpStrength;

	// Start is called before the first frame update
	void Start()
	{
		onGround = false;

		ball = gameObject.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D()
	{
		onGround = true;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow) && onGround)
		{
			onGround = false;
			ball.velocity = new Vector2(ball.velocity.x, jumpStrength);
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			if(ball.velocity.x > -maxSpeed)
				ball.velocity -= new Vector2(accel, 0f);
		}
		
		else
		{
			if(ball.velocity.x < 0)
				ball.velocity += new Vector2(accel, 0f);
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(ball.velocity.x < maxSpeed)
				ball.velocity += new Vector2(accel, 0f);
		}
		
		else
		{
			if(ball.velocity.x > 0)
				ball.velocity -= new Vector2(accel, 0f);
		}
	}
}
