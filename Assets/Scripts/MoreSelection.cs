using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoreSelection : MonoBehaviour
{
    GameObject BGM;

    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("BGM");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Selection2Main()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("World", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
            yield return null;

        SceneManager.MoveGameObjectToScene(BGM, SceneManager.GetSceneByName("World"));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
