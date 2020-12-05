using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public LevelManager Instance;

    public int TotalScenes { get; private set; }


    public int CurrentLevelIndex { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;

        TotalScenes = SceneManager.sceneCountInBuildSettings;
    }


    public void UpdateCurrentSceneIndex(int scene) => CurrentLevelIndex = scene;


    public void LoadLevel(int load)
    {
        if (!CheckLastLevel(load))
            StartCoroutine(LevelLoader.LoadLevel(load));
        else
            GameManager.Instance.GameWon();
    }


    public void LoadLevel(string stringLoad)
    {
        int load = GetBuildIndex(stringLoad);

        if (!CheckLastLevel(load))
            StartCoroutine(LevelLoader.LoadLevel(load));
        else
            GameManager.Instance.GameWon();
    }

    public void UnloadLevel(int unload) => StartCoroutine(LevelLoader.UnloadLevel(unload));


    public void UnloadLevel(string stringUnload)
    {
        int unload = GetBuildIndex(stringUnload);

        if (!CheckLastLevel(unload))
            StartCoroutine(LevelLoader.UnloadLevel(unload));
    }

    private bool CheckLastLevel(int level) => level >= TotalScenes;


    static public int GetBuildIndex(string levelName)
    {
        string levelPath = $"Assets/Scenes/{levelName}.unity";
        int levelIndex = SceneUtility.GetBuildIndexByScenePath(levelPath);
        return levelIndex;
    }
}