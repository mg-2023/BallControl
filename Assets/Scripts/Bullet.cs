using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Ball playerBall;

	public bool TowardUp { get; set; } = false;
	public bool TowardRight { get; set; } = false;
	public bool TowardDown { get; set; } = false;
	public bool TowardLeft { get; set; } = false;
	public float Speed { get; set; }

	// Start is called before the first frame update
	void Start()
	{
		playerBall = FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update()
	{
		if (TowardUp)
			transform.position += Vector3.up * Speed * Time.deltaTime;

		if (TowardRight)
			transform.position += Vector3.right * Speed * Time.deltaTime;

		if (TowardDown)
			transform.position += Vector3.down * Speed * Time.deltaTime;

		if (TowardLeft)
			transform.position += Vector3.left * Speed * Time.deltaTime;
	}

	// ignores trigger so bullet passes dash / jump item
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.CompareTag("Player"))
		{
			playerBall.transform.position = new Vector3(-14f + 32f * (playerBall.CurStage - 1), -6f, 0f);

			Ball.ballRB.velocity = new Vector2(0f, 0f);
			Ball.ballSR.color = new Color(1f, 1f, 0f, 1f);

			playerBall.DashEnabled = false;
			playerBall.JumpEnabled = false;
			playerBall.OnGround = false;
		}

		if(!col.collider.CompareTag("Bullet"))
			Destroy(gameObject);
	}
}
