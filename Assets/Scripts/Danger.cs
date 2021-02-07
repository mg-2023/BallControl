using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
	BoxCollider2D bc;
	Vector3 ballSpawn;
	
	public GameObject ball;
	
	// Start is called before the first frame update
	void Start()
	{
		bc = gameObject.GetComponent<BoxCollider2D>();
		ballSpawn = new Vector3(-14f, -6f, 0f);
	}
	
	void OnTriggerEnter2D()
	{
		ball.transform.position = ballSpawn;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
