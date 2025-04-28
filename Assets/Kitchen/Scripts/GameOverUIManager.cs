using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private Image blackImage;
    [SerializeField] private GameObject gameOverUI;

    private Color black = Color.black;

    private float fadeDuration = 3f;
    private float softFadeAlpha = 0.2f;

    private void Start()
    {
        GameManager.Instance.OnGameOver += OpenGameOverUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= OpenGameOverUI;
    }

    private IEnumerator FadeIn(float fadeAlpha)
    {
        blackImage.gameObject.SetActive(true);

        for (float a = 0; a < fadeDuration; a += Time.deltaTime)
        {
            blackImage.color = new Color(black.r, black.g, black.b, a * fadeAlpha);
            yield return null;
        }

        GameManager.Instance.StopGame();
    }

    public void OpenGameOverUI()
    {
        gameOverUI.SetActive(true);
        // * play animation

        StartCoroutine(FadeIn(softFadeAlpha));
    }
}
