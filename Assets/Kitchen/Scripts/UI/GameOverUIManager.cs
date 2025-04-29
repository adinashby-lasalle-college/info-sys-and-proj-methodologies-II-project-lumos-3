using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private Image newspaper;
    [SerializeField] private Sprite wrongHamburgerNews;
    [SerializeField] private Sprite bankruptcyNews;
    [SerializeField] private Sprite arrestedNews;

    private void Start()
    {
        GameManager.Instance.OnGameOver += PopUpGameOverUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= PopUpGameOverUI;
    }

    private void PopUpGameOverUI()
    {
        switch (GameManager.Instance.GameOverType)
        {
            case GameOverType.RENT:
                newspaper.sprite = bankruptcyNews;
                break;

            case GameOverType.CAUGHT:
                newspaper.sprite = arrestedNews;
                break;

            case GameOverType.HAMBURGER:
                newspaper.sprite = wrongHamburgerNews;
                break;
        }

        GetComponent<Animator>().SetTrigger("PopUp");
    }
}
