using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionButton : MonoBehaviour
{
	GameObject BGM;

	public Button[] stages = new Button[30];

	public static bool[] stageState = new bool[30];

    // Start is called before the first frame update
    void Start()
	{
		for(int i=0; i<30; i++)
		{
			if (i < Intro.maximum)
				stageState[i] = true;

			else
				stageState[i] = false;
		}
			
		for(int i=0; i<30; i++)
		{
			stages[i].GetComponentInChildren<Text>().text = (i+1).ToString();
		}

		BGM = GameObject.Find("BGM");
	}

	// Update is called once per frame
	void Update()
	{
		for(int i=0; i<30; i++)
		{
			stages[i].interactable = stageState[i];
		}
	}
}
