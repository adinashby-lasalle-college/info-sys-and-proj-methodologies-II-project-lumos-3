using UnityEngine;

public class RentManager : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;

    private int rent = 50;

    public void PayRent()
    {
        // If player cannot pay, game over
        if (MoneyManager.Instance.TotalMoney < rent)
        {
            GameManager.Instance.GameOver(GameOverType.RENT);
        }
        else
        {
            MoneyManager.Instance.Withdraw(rent);
            sceneLoader.LoadScene(2);
        }         
    }
}
