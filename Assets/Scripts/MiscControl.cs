using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscControl : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
        {
			SceneManager.LoadScene("Intro", LoadSceneMode.Single);
        }
	}
}
