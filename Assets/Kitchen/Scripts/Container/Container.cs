using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    [SerializeField] private IngredientSO ingredientSO;
    [SerializeField] private Transform tempSpawnPos; // temp

    private AnimationManager animationPlayer;
    private Ingredient ingredient;

    private void Start()
    {
        animationPlayer = GetComponentInChildren<AnimationManager>();
    }

    private void OnMouseEnter()
    {
        animationPlayer.TriggerAnimation("Open");
    }

    private void OnMouseExit()
    {
        animationPlayer.TriggerAnimation("Close");
    }

    public void Interact()
    {
        if (ingredient == null)
        {
            Transform ingredientTransform = Instantiate(ingredientSO.prefab);
            ingredientTransform.localPosition = Vector3.zero;

            ingredient = ingredientTransform.GetComponent<Ingredient>();

            Interactor.Instance.SetGrabbingIngredient(ingredient);
        }
    }
}
