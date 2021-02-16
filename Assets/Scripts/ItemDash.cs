﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDash : MonoBehaviour
{
	bool itemUsable = true;
	float regenCool;
	SpriteRenderer itemSR;
	BoxCollider2D itemBC;
	
	// Start is called before the first frame update
	void Start()
	{
		regenCool = 0f;
		
		itemBC = gameObject.AddComponent<BoxCollider2D>();
		itemBC.isTrigger = true;
		itemBC.tag = "Dash";
		
		itemSR = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.name == "Ball")
		{
			Destroy(GetComponent<BoxCollider2D>());
			regenCool = 0f;
			
			itemSR.color = new Color(1f, 1f, 1f, 0f);
			itemUsable = false;
			
			Ball.ballSR.color = Color.black;
			Ball.dashEnabled = true;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(!itemUsable)
		{
			regenCool += Time.deltaTime;
			itemSR.color = new Color(1f, 1f, 1f, regenCool);
			
			if(regenCool >= 1f)
			{
				itemBC = gameObject.AddComponent<BoxCollider2D>();
				itemBC.isTrigger = true;
				
				itemUsable = true;
			}
		}
	}
}
