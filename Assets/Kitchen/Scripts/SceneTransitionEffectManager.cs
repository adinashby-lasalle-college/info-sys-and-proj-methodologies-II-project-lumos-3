using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionEffectManager : MonoBehaviour
{
    [SerializeField] private Image blackImage;
    [SerializeField] private GameObject sumUpUI;
    [SerializeField] private GameObject gameOverUI;

    public static SceneTransitionEffectManager Instance { get; private set; }
    private Color black = Color.black;

    private float fadeDuration = 3f;
    private float softFadeAlpha = 0.2f;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

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

    private IEnumerator FadeOut()
    {
        GameManager.Instance.ResumeGame();

        for (float a = fadeDuration; a > 0; a -= Time.deltaTime)
        {
            blackImage.color = new Color(black.r, black.g, black.b, a);
            yield return null;
        }

        blackImage.gameObject.SetActive(false);
    }

    public IEnumerator OpenSumUpPage()
    {
        StartCoroutine(FadeIn(1)); // Completely fade in

        yield return new WaitForSeconds(1f);
        sumUpUI.SetActive(true);

        StartCoroutine(FadeOut());
    }

    public void OpenGameOverUI()
    {
        gameOverUI.SetActive(true);
        // * play animation

        StartCoroutine(FadeIn(softFadeAlpha));
    }
}
