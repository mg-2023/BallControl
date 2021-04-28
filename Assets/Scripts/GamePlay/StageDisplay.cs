using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageDisplay : MonoBehaviour
{
	Text stageText;
	public Ball playerBall;
	
	// Start is called before the first frame update
	void Start()
	{
		stageText = gameObject.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		stageText.text = $"Stage {playerBall.CurStage:00}";
	}
}
