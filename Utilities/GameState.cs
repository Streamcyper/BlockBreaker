using System;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public event Action OnUpdateLives;
    public event Action OnUpdateScore;

    private int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnUpdateScore?.Invoke();
        }
    }

    private int lives;

    public int Lives
    {
        get => lives;
        set
        {
            lives = value;
            OnUpdateLives?.Invoke();
        }
    }

    public int Level
    {
        get => LevelManager.Instance.CurrentLevelIndex;
        set => LevelManager.Instance.UpdateCurrentSceneIndex(value);
    }

    public HashSet<GameObject> Blocks;

    public GameState(int score, int lives, int level)
    {
        Score = score;
        Lives = lives;
        Level = level;
        Blocks = new HashSet<GameObject>();
    }
}