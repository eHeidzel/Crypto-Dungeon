using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Scrollbar progressBar;
    private string sceneToLoad = "MainMenu";

    private void Start()
    {
        PlayerPrefs.SetString("SceneToLoad","MainMenu");
        StartCoroutine(LoadSceneAsync());
    }
    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(1.3f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.size = progress;
            yield return new WaitForSeconds(0.5f);
            yield return null;
        }
    }
}