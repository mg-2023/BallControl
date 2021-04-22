using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndividualButton : MonoBehaviour
{
	Button button;
	GameObject BGM;

	// Start is called before the first frame update
	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(WarpStage);

		BGM = GameObject.Find("BGM");
	}

	/*
	// Update is called once per frame
	void Update()
	{
		
	}
	*/

	IEnumerator Selection2Main()
	{
		Scene currentScene = SceneManager.GetActiveScene();

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("World", LoadSceneMode.Additive);

		while (!asyncLoad.isDone)
			yield return null;

		SceneManager.MoveGameObjectToScene(BGM, SceneManager.GetSceneByName("World"));
		SceneManager.UnloadSceneAsync(currentScene);
	}

	void WarpStage()
	{
		int dest = transform.GetSiblingIndex() + 1;

		Intro.Current = dest;
		Debug.LogWarning($"Warped to stage {dest}");
		StartCoroutine(Selection2Main());
	}
}
