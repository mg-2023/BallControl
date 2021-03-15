using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscControl : MonoBehaviour
{
	GameObject BGM;

	// Start is called before the first frame update
	void Start()
	{
		BGM = GameObject.Find("BGM");
	}

	IEnumerator Main2Intro()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Intro2", LoadSceneMode.Additive);
		// "Intro2" because "Intro" already has BGM object
		// and if I actually move to "Intro" the game system screws

		// "Intro2" is the exact clone of the scene "Intro" except there's no BGM object

		while(!asyncLoad.isDone)
		{
			yield return null;
		}

		SceneManager.MoveGameObjectToScene(BGM, SceneManager.GetSceneByName("Intro2"));
		SceneManager.UnloadSceneAsync(currentScene);
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			StartCoroutine(Main2Intro());
		}
	}
}
