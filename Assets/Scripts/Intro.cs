using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
	float alpha = 0f;

	public static int current = 1;

	public Button startGame;
	public Button startFromRecent;
	public Button stageSelect;

	public Text NA;

	// Start is called before the first frame update
	void Start()
	{
		startGame.onClick.AddListener(GotoStage1);
		startFromRecent.onClick.AddListener(GotoRecent);
		stageSelect.onClick.AddListener(GotoSelect);

		NA.color = new Color(1f, 0f, 0f, 0f);

		startGame.GetComponentInChildren<Text>().text = "Start\n<size=16>(Reset progress)</size>";
	}

	void GotoStage1()
	{
		current = 1;
		SceneManager.LoadScene("World", LoadSceneMode.Single);
	}

	void GotoRecent()
	{
		SceneManager.LoadScene("World", LoadSceneMode.Single);
	}

	void GotoSelect()
	{
		alpha = 1f;
	}

	// Update is called once per frame
	void Update()
	{
		startFromRecent.GetComponentInChildren<Text>().text = 
			$"<size=32>Continue</size>\n<size=16>Current: {current}</size>";

		if (alpha > 0f)
		{
			alpha -= Time.deltaTime / 2f;
		}

		NA.color = new Color(1f, 0f, 0f, Mathf.Lerp(0f, 1f, alpha));
	}
}
