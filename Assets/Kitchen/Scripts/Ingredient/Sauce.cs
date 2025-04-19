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

        // If player is already grabbing a sauce bottle, replace the sauce bottle
        else if (Interactor.Instance.GetGrabbingObject().GetObjectType() == ObjectType.SAUCE)
        {
            // Put the grabbing sauce bottle back
            Sauce grabbingSauce = Interactor.Instance.GetGrabbingObject().GetComponent<Sauce>();
            grabbingSauce.PutSauceBottleBack();

            // Grab a new sauce bottle
            GetComponent<CursorFollower>().enabled = true;
            canPlayAnimation = false;

            Interactor.Instance.SetGrabbingObject(this);
        }
    }

    public void PutSauceBottleBack()
    {
        GetComponent<CursorFollower>().enabled = false;
        GetComponentInChildren<Collider>().enabled = true;
        canPlayAnimation = true;

        transform.position = originalTransform.position;

        animator.SetTrigger("MoveDown");

        Interactor.Instance.ClearGrabbingObject();
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
