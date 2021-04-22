using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
	public Transform root;
	public static Button[] buttons = new Button[30]; 

	// Start is called before the first frame update
	void Start()
	{
		int count = root.childCount - 1;
		for(int i=0; i<count; i++)
		{
			buttons[i] = root.GetChild(i).GetComponent<Button>();
			buttons[i].GetComponentInChildren<Text>().text = (i+1).ToString();
		}
	}

	// Update is called once per frame
	void Update()
	{
		int count = root.childCount - 1;

		for(int i=0; i<count; i++)
		{
			if (i < Intro.Maximum)
				buttons[i].interactable = true;

			else
				buttons[i].interactable = false;
		}
	}
}
