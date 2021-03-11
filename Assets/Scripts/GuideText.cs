using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideText : MonoBehaviour
{
	RectTransform rt;
	Text guideText;
	
	// Start is called before the first frame update
	void Start()
	{
		rt = gameObject.GetComponent<RectTransform>();
		guideText = gameObject.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		guideText.alignment = TextAnchor.MiddleCenter;
		guideText.color = new Color(1f, 1f, 1f, 1f);

		switch (Ball.curStage)
		{
			case 1:
				rt.anchoredPosition = new Vector2(0f, -30f);
				guideText.text = 
					"Left/Right arrow to move\n<size=16>Press ESC anytime to go back to main screen</size>";
				break;
				
			case 2:
				rt.anchoredPosition = new Vector2(0f, -30f);
				guideText.text = 
					"Up arrow to jump\n<size=16>Pro tip: Jump with slight delay if you hit the floor</size>";
				break;
				
			case 3:
				rt.anchoredPosition = new Vector2(0f, 80f);
				guideText.text = "Be careful of that red thingy";
				break;
				
			case 4:
				rt.anchoredPosition = new Vector2(0f, 120f);
				guideText.text = "Jump past that red thingy... Yeah it gets harder";
				break;
				
			case 5:
				rt.anchoredPosition = new Vector2(0f, 120f);
				guideText.text = "This is even harder!! Good luck";
				break;
				
			case 6:
				rt.anchoredPosition = new Vector2(0f, 0f);
				guideText.text = "Dash Usage - Hold arrow key and press \'Z\'";
				break;
				
			case 7:
				rt.anchoredPosition = new Vector2(0f, 120f);
				guideText.text = "Just one dash.. with control!!";
				break;

			case 8:
				rt.anchoredPosition = new Vector2(0f, 120f);
				guideText.alignment = TextAnchor.MiddleRight;
				guideText.text = "Get ready for more controls!";
				break;
				
			case 9:
				rt.anchoredPosition = new Vector2(0f, 80f);
				guideText.text = "3 dashes in a row!!";
				break;
				
			case 10:
				rt.anchoredPosition = new Vector2(0f, 0f);
				guideText.text = "Jump Usage - Hold arrow key and press \'X\'";
				break;
				
			case 11:
				rt.anchoredPosition = new Vector2(0f, 80f);
				guideText.alignment = TextAnchor.MiddleLeft;
				guideText.text = "6 jumps in a row.. again!!";
				break;
				
			case 12:
				rt.anchoredPosition = new Vector2(0f, 80f);
				guideText.text = "Don\'t get confused.. There\'re two items now!";
				break;
				
			case 13:
				rt.anchoredPosition = new Vector2(0f, 225f);
				guideText.text = "More item changes.. and increasing difficulty";
				break;

			case 14:
				rt.anchoredPosition = new Vector2(0f, 250f);
				guideText.alignment = TextAnchor.MiddleLeft;
				guideText.text = "Challenge accepted: jumping over the wall";
				break;

			case 15:
				rt.anchoredPosition = new Vector2(0f, 0f);
				guideText.text = "More stages coming soon...";
				break;

			default:
				guideText.color = new Color(1f, 1f, 1f, 0f);
				break;
		}
	}
}
