using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrans : MonoBehaviour
{
	BoxCollider2D bc;
	
	[Tooltip("Insert \'ball\'(player) here")]
	public GameObject ball;
	[Tooltip("Insert main camera here")]
	public GameObject cam;
	
	// Start is called before the first frame update
	void Start()
	{
		bc = gameObject.AddComponent<BoxCollider2D>();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		for(int i=0; i<Ball.curStage; i++)
        {
			SelectionButton.stageState[Ball.curStage] = true;
		}

		Ball.curStage++;
		Intro.maximum++;

		ball.transform.position = new Vector3(-14f + 32f*(Ball.curStage-1), -6f, 0f);
		Ball.ballRB.velocity = new Vector2(0f, 0f);

		cam.transform.position = new Vector3(32f*(Ball.curStage-1), 0f, -1f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
