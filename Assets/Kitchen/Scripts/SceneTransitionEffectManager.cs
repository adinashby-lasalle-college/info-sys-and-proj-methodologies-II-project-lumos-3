using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionEffectManager : MonoBehaviour
{
    [SerializeField] private Image blackImage;
    [SerializeField] private GameObject SumUpUI;

    public static SceneTransitionEffectManager Instance { get; private set; }
    private Color black = Color.black;
    private float fadeDuration = 3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private IEnumerator FadeIn()
    {
        for (float a = 0; a < fadeDuration; a += Time.deltaTime)
        {
            blackImage.color = new Color(black.r, black.g, black.b, a);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        for (float a = fadeDuration; a > 0; a -= Time.deltaTime)
        {
            blackImage.color = new Color(black.r, black.g, black.b, a);
            yield return null;
        }

        blackImage.gameObject.SetActive(false);
    }

    public IEnumerator OpenSumUpPage()
    {
        StartCoroutine(FadeIn());

        yield return new WaitForSeconds(1f);
        SumUpUI.SetActive(true);

        StartCoroutine(FadeOut());
    }
}
