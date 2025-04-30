using UnityEngine;

public class NightToDayUIManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        // Night To Day UI won't pop up on the first day
        if (DayTimeTimer.Instance.CurrDay > 1)
        {
            animator.SetTrigger("Switch");
        }
    }
}
