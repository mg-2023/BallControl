using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideText : MonoBehaviour
{
	RectTransform rt;
	Text guideText;
	Ball playerBall;

	string[] guideTexts = new string[30];
	float[] YPositions = {-30, -30, 150, 180, -165, 30, 30, 120, 120, 80, 30, 
	                      45, -210, 225, 250, -135, 0, -155, -255, 265, -230, 
	                      150, 165, 200, 85, 0, 0, 0, 0, 0};
	int[] anchors = {4, 4, 4, 4, 4, 4, 4, 4, 5, 4, 
	                 4, 3, 4, 4, 3, 5, 3, 3, 5, 3, 
	                 5, 4, 5, 5, 3, 4, 4, 4, 4, 4};
	// 3: MiddleLeft
	// 4: MiddleCenter (default)
	// 5: MiddleRight

	// Start is called before the first frame update
	void Start()
	{
		rt = gameObject.GetComponent<RectTransform>();
		guideText = gameObject.GetComponent<Text>();
		playerBall = FindObjectOfType<Ball>();

		try
		{
			using(var reader = new StreamReader("Assets/Scripts/GamePlay/guidetextlist.txt"))
			{
				for(int i=0; i<guideTexts.Length; i++)
				{
					guideTexts[i] = reader.ReadLine();
					string addition = reader.ReadLine();
					if(addition != "")
						guideTexts[i] += $"\n{addition}";
				}
			}
		} catch(IOException ex) {
			// simple way to remove that nasty warning
			Debug.LogError(ex.Message);
		}
	}

	// Update is called once per frame
	void Update()
	{
		guideText.color = Color.white;

		// finally did it!!!
		if(playerBall.CurStage >= 1 && playerBall.CurStage <= 30) {
			int i = playerBall.CurStage;

			rt.anchoredPosition = new Vector2(0f, YPositions[i-1]);
			guideText.alignment = (TextAnchor)anchors[i-1];
			guideText.text = guideTexts[i-1];
		}
	}
}
