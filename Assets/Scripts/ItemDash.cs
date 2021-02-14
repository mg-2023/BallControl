using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDash : MonoBehaviour
{
	BoxCollider2D bc;
	
	public GameObject ball;
	
	// Start is called before the first frame update
	void Start()
	{
		bc = gameObject.AddComponent<BoxCollider2D>();
	}
	
	void OnColliderEnter2D()
	{
		ball.SpriteRenderer.color = new Color(0f, 0f, 0f, 1f);
		
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
