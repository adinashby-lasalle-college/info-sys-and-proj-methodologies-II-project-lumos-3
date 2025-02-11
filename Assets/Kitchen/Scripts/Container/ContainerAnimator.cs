using UnityEngine;

public class ContainerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayOpenAnimation()
    {
        animator.SetTrigger("Open");
    }

    public void PlayCloseAnimation()
    {
        animator.SetTrigger("Close");
    }
}
