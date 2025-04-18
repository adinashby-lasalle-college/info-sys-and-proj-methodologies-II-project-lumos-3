using UnityEngine;

public class RentManager : MonoBehaviour
{
    private int rent = 50;

    public void PayRent()
    {
        MoneyManager.Instance.Withdraw(rent);
    }
}
