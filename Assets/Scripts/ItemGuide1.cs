using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGuide1 : MonoBehaviour
{
	RectTransform rt;
	Text dashGuide;
	
	// Start is called before the first frame update
	void Start()
	{
		rt = gameObject.GetComponent<RectTransform>();
		dashGuide = gameObject.GetComponent<Text>();
		Debug.Log("Hello World!!!!");
	}

	// Update is called once per frame
	void Update()
	{
		rt.anchoredPosition = new Vector2(0f, -30f);
		
		switch(Ball.curStage)
		{
			case 1:
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Left/Right arrow to move";
				break;
				
			case 2:
				rt.anchoredPosition = new Vector2(0f, -30f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Up arrow to jump";
				break;
				
			case 3:
				rt.anchoredPosition = new Vector2(0f, 80f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Be careful of that red thingy";
				break;
				
			case 4:
				rt.anchoredPosition = new Vector2(0f, 120f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Jump past that red thingy... Yeah it gets harder";
				break;
				
			case 5:
				rt.anchoredPosition = new Vector2(0f, 120f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "This is even harder!! Good luck";
				break;
				
			case 6:
				rt.anchoredPosition = new Vector2(0f, -30f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Dash Usage - Hold arrow key and press \'Z\'";
				break;
				
			case 7:
				rt.anchoredPosition = new Vector2(0f, 120f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Just one dash.. with control!!";
				break;
				
			case 9:
				rt.anchoredPosition = new Vector2(0f, 80f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "3 dashes in a row!!";
				break;
				
			case 10:
				rt.anchoredPosition = new Vector2(0f, -30f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Jump Usage - Hold arrow key and press \'X\'";
				break;
				
			case 11:
				rt.anchoredPosition = new Vector2(0f, 80f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "6 jumps in a row.. again!!";
				break;
				
			case 12:
				rt.anchoredPosition = new Vector2(0f, 80f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Don\'t get confused.. There\'re two items now!";
				break;
				
			case 13:
				rt.anchoredPosition = new Vector2(0f, 225f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "More item changes.. and increasing difficulty";
				break;

			case 14:
				rt.anchoredPosition = new Vector2(0f, 125f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "Challenge accepted: jumping over the wall";
				break;

			case 15:
				rt.anchoredPosition = new Vector2(0f, 0f);
				dashGuide.color = new Color(1f, 1f, 1f, 1f);
				dashGuide.text = "There are no stages behind..\nCongratulations!!";
				break;

			default:
				dashGuide.color = new Color(1f, 1f, 1f, 0f);
				break;
		}
	}
}
