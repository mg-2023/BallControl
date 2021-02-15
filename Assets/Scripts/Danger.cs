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
	
	void OnTriggerEnter2D()
	{
		ball.transform.position = new Vector3(-14f + 32f*(Ball.curStage-1), -6f, 0f);
		Ball.sr.color = new Color(1f, 1f, 0f, 1f);
		Ball.dashEnabled = false;
		
		ItemDash.sr.color = new Color(1f, 1f, 1f, 1f);
		ItemDash.bc = gameObject.AddComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
