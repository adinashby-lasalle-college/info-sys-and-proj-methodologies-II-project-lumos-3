using UnityEngine;
using UnityEngine.UI;

public class GrillTimerUIManager : MonoBehaviour
{
    [SerializeField] private Grill grill;
    [SerializeField] private Image bar;

    private void FixedUpdate()
    {
        switch (grill.GetCurrState())
        {
            case Grill.State.IDLE:
                bar.color = Color.green;
                bar.fillAmount = 0f;
                break;

            case Grill.State.COOKING:
                bar.fillAmount = grill.CookTime / grill.DoneTime;
                break;

            case Grill.State.COOKED:
                bar.color = Color.red;
                bar.fillAmount = grill.CookTime / grill.BurntTime;
                break;
        } 
    }
}
