﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStage2 : MonoBehaviour
{
	public GameObject ball;
	
	BoxCollider2D box;
	
	// Start is called before the first frame update
	void Start()
	{
		box = gameObject.AddComponent<BoxCollider2D>();
	}

	void OnCollisionEnter2D()
	{
		SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
		ball.transform.position = new Vector3(-14f, -6f, 0f);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
