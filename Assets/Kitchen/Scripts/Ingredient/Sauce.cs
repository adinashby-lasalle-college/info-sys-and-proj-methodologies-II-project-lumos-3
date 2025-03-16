using UnityEngine;

public class Sauce : Grabbable, IInteractable
{
    [SerializeField] private IngredientSO sauceSO;
    [SerializeField] private Transform originalTransform;

    private AnimationManager animationPlayer;
    private bool canPlayAnimation = true;

    private void Start()
    {
        animationPlayer = GetComponentInChildren<AnimationManager>();
    }

    private void OnMouseEnter()
    {
        if (canPlayAnimation)
        {
            animationPlayer.TriggerAnimation("MoveUp");
        }
    }

    private void OnMouseExit()
    {
        if (canPlayAnimation)
        {
            animationPlayer.TriggerAnimation("MoveDown");
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

        animationPlayer.TriggerAnimation("MoveDown");
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
