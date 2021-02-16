using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
	BoxCollider2D bc;
	
	public GameObject ball;
	
	// Start is called before the first frame update
	void Start()
	{
		bc = gameObject.GetComponent<BoxCollider2D>();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.name == "Ball")
		{
			ball.transform.position = new Vector3(-14f + 32f*(Ball.curStage-1), -6f, 0f);
			
			Ball.ballRB.velocity = new Vector2(0f, 0f);
			Ball.ballSR.color = new Color(1f, 1f, 0f, 1f);
			Ball.dashEnabled = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
