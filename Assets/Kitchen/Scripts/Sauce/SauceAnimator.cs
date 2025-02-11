using UnityEngine;

public class SauceAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}
