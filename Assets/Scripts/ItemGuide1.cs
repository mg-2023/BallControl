using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGuide1 : MonoBehaviour
{
	Text dashGuide;
	
	// Start is called before the first frame update
	void Start()
	{
		dashGuide = gameObject.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Ball.curStage == 6)
			dashGuide.color = new Color(1f, 1f, 1f, 1f);
		
		else
			dashGuide.color = new Color(1f, 1f, 1f, 0f);
	}
}
