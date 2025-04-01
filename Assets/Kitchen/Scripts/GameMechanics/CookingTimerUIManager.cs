using UnityEngine;
using UnityEngine.UI;

public class CookingTimerUIManager : MonoBehaviour
{
    [SerializeField] private Image bar;

    private bool isActive = false;

    private void Start()
    {
        CookingTimer.Instance.OnCookingTimerStart += SetCookingTimerUIActive;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            bar.fillAmount = CookingTimer.Instance.TimerTime / CookingTimer.Instance.TimerMax;

            if (CookingTimer.Instance.TimerTime >= PriceManager.Instance.GetHighPriceTimeLimit())
            {
                bar.color = Color.yellow;
            }

            if (CookingTimer.Instance.TimerTime >= PriceManager.Instance.GetMiddlePriceTimeLimit())
            {
                bar.color = Color.red;
            }
        }
    }

    private void SetCookingTimerUIActive()
    {
        isActive = true;

        bar.color = Color.green;
    }
}
