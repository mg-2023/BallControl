using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	bool onGround;

	public int startLevel = 1;
	
	// TODO: minimize static variable count
	public static int curStage = 1;
	public static bool dashEnabled;
	public static bool jumpEnabled;
	public static SpriteRenderer ballSR;
	public static Rigidbody2D ballRB;
	
	// public int startLevel=1;
	public float accel, maxSpeed, jumpStrength;
	public Camera cam;
	
	// Start is called before the first frame update
	void Start()
	{
		onGround = false;

		ballRB = gameObject.GetComponent<Rigidbody2D>();
		ballSR = gameObject.GetComponent<SpriteRenderer>();

		curStage = startLevel;
		// curStage = Intro.current;
		
		cam.transform.position = new Vector3((curStage-1)*32f, 0f, -1f);
		transform.position = new Vector3(-14f + (curStage-1)*32f, -6f, 0f);
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
		if(Input.GetKeyDown(KeyCode.Z) && dashEnabled)
		{
			ballRB.velocity = new Vector2((ballRB.velocity.x > 0) ? 15f : -15f, 5f);
			
			ballSR.color = Color.yellow;
			dashEnabled = false;
		}
		
		// coltroller while jump item is enabled
		if(Input.GetKeyDown(KeyCode.X) && jumpEnabled)
		{
			ballRB.velocity = new Vector2((ballRB.velocity.x > 0) ? 5f : -5f, 12f);
			
			ballSR.color = Color.yellow;
			jumpEnabled = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		PlayerMove();
		ItemControl();
		
		cam.backgroundColor = new Color(0f, (curStage+15f)/60f, 0f, 1f);
	}
}
