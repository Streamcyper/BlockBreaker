using Sirenix.OdinInspector;
using System;
using UnityEngine;

[RequireComponent(typeof(GameMode))]
public class GameManager : MonoBehaviour
{
    static public GameManager Instance;
    public Action<bool> OnInMenu;
    public Action OnStartGame;
    public Action<bool> OnPause;
    public GameState State;
    public bool InMenu { get; set; } = true;


    [SerializeField]
    [ValidateInput("MoreThanZero", "Must be more than 0")]
    [PropertyTooltip("The number of lives the player starts with.")]
    private int lives = 5;


    public void AddPoints(int points) => State.Score += points;

    public void AddLives(int lives) => State.Lives += lives;

    public void AddBlock(GameObject block) => State.Blocks.Add(block);

    public void RemoveBlock(GameObject block)
    {
        State.Blocks.Remove(block);

        if (!MoreThanZero(State.Blocks.Count)) LevelComplete();
    }

    public void GameLost()
    {
        LevelManager.Instance.UnloadLevel(LevelManager.Instance.CurrentLevelIndex);
        LevelManager.Instance.LoadLevel("EndMenu");
        OnInMenu?.Invoke(true);
    }

    public void GameWon()
    {
        LevelManager.Instance.LoadLevel("WonGame");
        OnInMenu?.Invoke(true);
    }

    public void GameStart()
    {
        if (State == null)
        {
            int firstLevel = LevelManager.GetBuildIndex("Levels/Level1");
            State = new GameState(0, lives, firstLevel);
        }

        LevelManager.Instance.LoadLevel(State.Level);
        OnStartGame?.Invoke();
    }

    public void LevelComplete()
    {
        LevelManager.Instance.UnloadLevel(State.Level);
        State.Level++;
        FindObjectOfType<Ball>().ResetBall();
        LevelManager.Instance.LoadLevel(State.Level);
    }

    public void CheckPointSave() => lastCheckpoint = State;

    public void CheckPointLoad()
    {
        State = lastCheckpoint;
        GameStart();
    }

    public void ToggleInMenu(bool menu) => InMenu = menu;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        OnInMenu += ToggleInMenu;

        mode = GetComponent<GameMode>();
        LevelManager.Instance.LoadLevel("MainMenu");
    }

    private void Update()
    {
        if (!InMenu)
            mode.CheckConditions();
    }

    private bool MoreThanZero(int value) => value > 0;
    private GameMode mode;
    private GameState lastCheckpoint;
}