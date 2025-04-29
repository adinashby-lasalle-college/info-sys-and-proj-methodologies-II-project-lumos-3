using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameOverType GameOverType { get; private set; }
    public event Action OnGameOver;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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

    public void GameOver(GameOverType type)
    {
        GameOverType = type;

        Interactor.Instance.BlockInteract();
        OnGameOver?.Invoke();
    }
}

public enum GameOverType
{
    HAMBURGER,
    RENT,
    CAUGHT
}