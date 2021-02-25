using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	bool onGround;
	
	// 이 변수는 다음으로 넘어가는 오브젝트가 갖고있는 스크립트가 접근 가능하게 하려고 한 것
	public static int curStage = 1;
	
	// 아래 4개는 장애물이나 아이템이 갖고있는 스크립트가 접근 가능하게 하려고 한 것
	public static bool dashEnabled;
	public static bool jumpEnabled;
	public static SpriteRenderer ballSR;
	public static Rigidbody2D ballRB;
	
	public int startLevel=1;
	public float accel, maxSpeed, jumpStrength;
	public Camera cam;
	
	// Start is called before the first frame update
	void Start()
	{
		onGround = false;

		ballRB = gameObject.GetComponent<Rigidbody2D>();
		ballSR = gameObject.GetComponent<SpriteRenderer>();
		
		cam.transform.position = new Vector3((startLevel-1)*32f, 0f, -1f);
		transform.position = new Vector3(-14f + (startLevel-1)*32f, -6f, 0f);
		
		curStage = startLevel;
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
		
		// 대시 아이템을 먹은 상태에서 조정하는 것
		if(Input.GetKeyDown(KeyCode.Z) && dashEnabled)
		{
			if(ballRB.velocity.x > 0)
				ballRB.velocity = new Vector2(15f, 5f);
			
			else
				ballRB.velocity = new Vector2(-15f, 5f);
			
			ballSR.color = Color.yellow;
			dashEnabled = false;
		}
		
		// 점프 아이템을 먹은 상태에서 조정하는 것
		if(Input.GetKeyDown(KeyCode.X) && jumpEnabled)
		{
			ballRB.velocity = new Vector2(ballRB.velocity.x, 12f);
			
			ballSR.color = Color.yellow;
			jumpEnabled = false;
		}
	}
}
