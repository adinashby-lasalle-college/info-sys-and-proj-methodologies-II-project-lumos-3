using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action OnGameOver;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
