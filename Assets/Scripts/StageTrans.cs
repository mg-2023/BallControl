using System;
using UnityEngine;

public class StageTrans : MonoBehaviour
{
	BoxCollider2D bc;
	// IDE suggests that i can delete this field but i can't b/c Start() method

	Ball playerBall;
	
	public GameObject ball;
	public GameObject cam;
	
	// Start is called before the first frame update
	void Start()
	{
		bc = gameObject.AddComponent<BoxCollider2D>();
		playerBall = FindObjectOfType<Ball>();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		playerBall.CurStage++;
		if(playerBall.CurStage > Intro.Maximum)
			Intro.Maximum++;

		ball.transform.position = new Vector3(-14f + 32f*(playerBall.CurStage-1), -6f, 0f);
		Ball.ballRB.velocity = new Vector2(0f, 0f);

		cam.transform.position = new Vector3(32f*(playerBall.CurStage-1), 0f, -1f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
