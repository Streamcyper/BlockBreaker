using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Action onUIUpdate;

    static public UIManager Instance;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
        GameManager.Instance.OnStartGame += StartUI;
    }

    [SerializeField] [Required] private TextMeshProUGUI livesText = default;
    [SerializeField] [Required] private TextMeshProUGUI scoreText = default;

    public void StartUI()
    {
        GameManager.Instance.State.OnUpdateLives += UpdateUILives;
        GameManager.Instance.State.OnUpdateScore += UpdateUIScore;
        UpdateUILives();
        UpdateUIScore();
    }

    public void UpdateUILives()
    {
        livesText.text = $"Lives: {GameManager.Instance.State.Lives}";
        onUIUpdate += UpdateUILives;
    }

    public void UpdateUIScore()
    {
        scoreText.text = $"Score: {GameManager.Instance.State.Score}";
        onUIUpdate += UpdateUIScore;
    }

    private void LateUpdate()
    {
        onUIUpdate?.Invoke();
        onUIUpdate = null;
    }
}