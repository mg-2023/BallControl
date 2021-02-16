using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDash : MonoBehaviour
{
	bool itemUsable = true;
	float regenCool;
	// 실시간으로 올라가는 재생성 타이머
	
	SpriteRenderer itemSR;
	BoxCollider2D itemBC;
	
	public float regenTime = 1f;
	// 재생성되기까지 걸리는 시간, 기본은 1초이나 바꿀 수 있음
	
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
			itemSR.color = new Color(1f, 1f, 1f, regenCool/regenTime);
			
			if(regenCool >= regenTime)
			{
				itemBC = gameObject.AddComponent<BoxCollider2D>();
				itemBC.isTrigger = true;
				
				itemUsable = true;
			}
		}
	}
}
