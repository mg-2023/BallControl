using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	bool onGround;

	public int startLevel = 1;

	public int CurStage { get; set; } = 1;
	public bool DashEnabled { get; set; } = false;
	public bool JumpEnabled { get; set; } = false;

	public static SpriteRenderer ballSR;
	public static Rigidbody2D ballRB;

	[Header("Ball Properties")]
	public float accel;
	public float maxSpeed;
	public float jumpStrength;

	[Header("Main Camera")]
	public Camera cam;
	
	// Start is called before the first frame update
	void Start()
	{
		onGround = false;

		ballRB = gameObject.GetComponent<Rigidbody2D>();
		ballSR = gameObject.GetComponent<SpriteRenderer>();

		CurStage = Intro.Current;
		
		cam.transform.position = new Vector3((CurStage-1)*32f, 0f, -1f);
		transform.position = new Vector3(-14f + (CurStage-1)*32f, -6f, 0f);
	}

	// Update is called once per frame
	void Update()
	{
		PlayerMove();
		ItemControl();
		
		cam.backgroundColor = new Color(0f, (CurStage+15f)/60f, 0f, 1f);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (ballRB.velocity.x > maxSpeed)
			ballRB.velocity = new Vector2(maxSpeed, ballRB.velocity.y);

		else if (ballRB.velocity.x < -maxSpeed)
			ballRB.velocity = new Vector2(-maxSpeed, ballRB.velocity.y);
	}


	// player is able to jump when collided with manually sized trigger collider
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Floor") || collider.CompareTag("Tile"))
			onGround = true;
	}

	void PlayerMove()
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
				ballRB.velocity -= new Vector2(accel, 0f) * Time.deltaTime;
		}
		
		else
		{
			if(ballRB.velocity.x < 0)
				ballRB.velocity += new Vector2(accel, 0f) * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			if(ballRB.velocity.x < maxSpeed)
				ballRB.velocity += new Vector2(accel, 0f) * Time.deltaTime;
		}
		
		else
		{
			if(ballRB.velocity.x > 0)
				ballRB.velocity -= new Vector2(accel, 0f) * Time.deltaTime;
		}
	}
	
	void ItemControl()
	{
		// controller while dash item is enabled
		if(Input.GetKeyDown(KeyCode.Z) && DashEnabled)
		{
			ballRB.velocity = new Vector2((ballRB.velocity.x > 0) ? 15f : -15f, 5f);
			
			ballSR.color = Color.yellow;
			DashEnabled = false;
		}
		
		// controller while jump item is enabled
		if(Input.GetKeyDown(KeyCode.X) && JumpEnabled)
		{
			ballRB.velocity = new Vector2((ballRB.velocity.x > 0) ? 5f : -5f, 12f);
			
			ballSR.color = Color.yellow;
			JumpEnabled = false;
		}
	}
}
