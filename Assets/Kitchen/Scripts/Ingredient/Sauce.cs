using UnityEngine;

public class Sauce : Grabbable, IInteractable
{
    [SerializeField] private IngredientSO sauceSO;
    [SerializeField] private Transform originalTransform;

    private Animator animator;
    private bool canPlayAnimation = true;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnMouseEnter()
    {
        if (canPlayAnimation)
        {
            animator.SetTrigger("MoveUp");
        }
    }

    private void OnMouseExit()
    {
        if (canPlayAnimation)
        {
            animator.SetTrigger("MoveDown");
        }
    }

    public void Interact()
    {
        // Grab this sauce bottle
        if (!Interactor.Instance.IsGrabbing)
        {
            GetComponent<CursorFollower>().enabled = true;
            canPlayAnimation = false;

            Interactor.Instance.SetGrabbingObject(this);
        }
    }

    public void PutSauceBottleBack()
    {
        GetComponent<CursorFollower>().enabled = false;
        canPlayAnimation = true;

        transform.position = originalTransform.position;

        animator.SetTrigger("MoveDown");
    }

    public override ObjectType GetObjectType()
    {
        return ObjectType.SAUCE;
    }

    public IngredientSO GetIngredientSO()
    {
        return sauceSO; 
    }
}
