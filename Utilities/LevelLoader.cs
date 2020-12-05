using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class LevelLoader
{
    static public IEnumerator LoadLevel(int scene)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        while (!sceneLoading.isDone)
        {
            LevelManager.Instance.UpdateCurrentSceneIndex(scene);
            yield return null;
        }
    }

    static public IEnumerator UnloadLevel(int scene)
    {
        AsyncOperation sceneUnloading = SceneManager.UnloadSceneAsync(scene);

        while (!sceneUnloading.isDone) yield return null;
    }
}