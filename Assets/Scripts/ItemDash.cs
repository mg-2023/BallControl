using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDash : MonoBehaviour
{
	/*
	public static ItemDash Instance;
	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
	}
	*/
	public static SpriteRenderer sr;
	public static BoxCollider2D bc;
	// public GameObject obj;
	
	// Start is called before the first frame update
	void Start()
	{
		bc = gameObject.AddComponent<BoxCollider2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		
		bc.isTrigger = true;
	}
	
	void OnTriggerEnter2D()
	{
		Ball.sr.color = Color.black;
		Ball.dashEnabled = true;
		sr.color = new Color(1f, 1f, 1f, 0f);
		Destroy(bc);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
