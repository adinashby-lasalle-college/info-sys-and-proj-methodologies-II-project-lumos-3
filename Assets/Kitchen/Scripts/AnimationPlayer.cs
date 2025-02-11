using UnityEngine;

public class AnimationPlayer : MonoBehaviour
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
