using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void StartGame()
    {
        RunStart("MainMenu");
        UIManager.Instance.StartUI();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        GameManager.Instance.State = null;
        RunStart("EndMenu");
    }

    public void PlayAgain()
    {
        GameManager.Instance.State = null;
        RunStart("WonGame");
    }

    private void RunStart(string scene)
    {
        GameManager.Instance.GameStart();
        GameManager.Instance.OnInMenu?.Invoke(false);
        LevelManager.Instance.UnloadLevel(scene);
    }
}