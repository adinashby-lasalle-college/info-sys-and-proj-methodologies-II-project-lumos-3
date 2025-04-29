using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
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
        GetComponent<Animator>().SetTrigger("PopUp");
    }
}
