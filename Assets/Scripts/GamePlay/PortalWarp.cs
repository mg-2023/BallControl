using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PortalWarp : MonoBehaviour
{
	BoxCollider2D portalInBC;

	public GameObject portalOut;

	// Start is called before the first frame update
	void Start()
	{
		portalInBC = gameObject.GetComponent<BoxCollider2D>();
		portalInBC.isTrigger = true;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		GameObject obj = col.gameObject;

		obj.transform.position = portalOut.transform.position;
	}

	/*
	// Update is called once per frame
	void Update()
	{
		
	}
	*/
}
