using UnityEngine;
using UnityEngine.UI;

public class CookingTimerUIManager : MonoBehaviour
{
    [SerializeField] private PriceManager priceManager;
    [SerializeField] private CookingTimer cookingTimer;
    [SerializeField] private Bell bell;
    [SerializeField] private Animator animator;
    [SerializeField] private Image bar;

    private bool isActive = false;

    private void Start()
    {
        cookingTimer.OnCookingTimerStart += SetCookingTimerUIActive;
        bell.OnServed += HideCookingTimerUI;

        bar.fillAmount = 0;
    }

    private void OnDisable()
    {
        cookingTimer.OnCookingTimerStart -= SetCookingTimerUIActive;
        bell.OnServed -= HideCookingTimerUI;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            bar.fillAmount = cookingTimer.CookTime / cookingTimer.TimerMax;

            if (cookingTimer.CookTime >= priceManager.GetHighPriceTimeLimit())
            {
                bar.color = Color.yellow;
            }

            if (cookingTimer.CookTime >= priceManager.GetMiddlePriceTimeLimit())
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

    private void HideCookingTimerUI()
    {
        animator.SetTrigger("Served");
    }
}
