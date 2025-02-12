using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    [SerializeField] private IngredientSO ingredientSO;
    [SerializeField] private Transform tempSpawnPos; // temp

    private AnimationManager animationPlayer;

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
        Transform ingredient = Instantiate(ingredientSO.prefab, tempSpawnPos);
        ingredient.localPosition = Vector3.zero;

        // * Attach ingredient to the mouse cursor
        
        Debug.Log("Interacting with " + this.name);
    }
}
