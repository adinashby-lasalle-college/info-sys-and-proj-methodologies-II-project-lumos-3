using UnityEngine;
using UnityEngine.UI;

public class CookingTimerUIManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Image bar;

    private bool isActive = false;

    private void Start()
    {
        CookingTimer.Instance.OnCookingTimerStart += SetCookingTimerUIActive;
        Bell.Instance.OnServed += HideCookingTimerUI;

        bar.fillAmount = 0;
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
        animator.SetTrigger("Start");

        isActive = true;

        bar.color = Color.green;
    }

    private void HideCookingTimerUI(int price)
    {
        animator.SetTrigger("Served");
    }
}
