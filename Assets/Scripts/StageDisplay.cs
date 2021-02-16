using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageDisplay : MonoBehaviour
{
	Text stageText;
	public GameObject ball;
	
	// Start is called before the first frame update
	void Start()
	{
		stageText = gameObject.GetComponent<Text>();
		stageText.text = "Stage 1";
	}

	// Update is called once per frame
	void Update()
	{
		stageText.text = "Stage " + Ball.curStage;
	}
}
