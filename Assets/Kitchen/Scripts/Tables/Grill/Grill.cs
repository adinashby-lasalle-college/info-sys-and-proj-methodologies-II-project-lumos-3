using UnityEngine;

public class Grill : Table, IInteractable
{
    [SerializeField] CookableIngredientSO[] cookableIngredientSOList;

    private State currState = State.IDLE;

    public float CookTime { get; private set; } = 0f;
    public float DoneTime { get; private set; } = 2f;
    public float BurntTime { get; private set; } = 2f;

    private void FixedUpdate()
    {
        // If a cookable ingredient is on the grill, start cooking
        if (ingredientOnTable)
        {
            switch (currState)
            {
                case State.IDLE:
                    {
                        CookTime = 0f;
                        currState = State.COOKING;
                        break;
                    }

                case State.COOKING:
                    {
                        CookTime += Time.deltaTime;

                        // When it's cooked, switch the raw ingredient to the cooked version
                        if (CookTime >= DoneTime)
                        {
                            IngredientSO cookedMeatSO = GetCookedIngredientSO(ingredientOnTable.GetIngredientSO());
                            ingredientOnTable.DestroySelf();

                            Ingredient cookedMeat = Ingredient.SpawnIngredient(cookedMeatSO);
                            SwitchIngredient(cookedMeat);

                            CookTime = 0f;

                            currState = State.COOKED;
                        }

                        break;
                    }

                case State.COOKED:
                    {
                        CookTime += Time.deltaTime;

                        if (CookTime >= BurntTime)
                        {
                            IngredientSO burntMeatSO = GetBurntIngredientSO(ingredientOnTable.GetIngredientSO());
                            ingredientOnTable.DestroySelf();

                            Ingredient burntMeat = Ingredient.SpawnIngredient(burntMeatSO);
                            SwitchIngredient(burntMeat);

                            currState = State.BURNT;
                        }

                        break;
                    }

                case State.BURNT:
                    {
                        break;
                    }
            }
        }
    }

    public void Interact()
    {
        if (Interactor.Instance.IsGrabbing)
        {
            Grabbable grabbingIngredient = Interactor.Instance.GetGrabbingObject();

            // Check if the grabbing ingredient cookable
            if (grabbingIngredient.GetObjectType() == ObjectType.COOKABLE && !ingredientOnTable)
            {
                // Put the ingredient on this table
                PutIngredient(grabbingIngredient.GetComponent<Ingredient>());
            }
        }

        else if (ingredientOnTable)
        {
            // Pick up the ingredient on this table
            ingredientOnTable.transform.parent = null;
            ingredientOnTable.GetComponent<CursorFollower>().enabled = true;

            Interactor.Instance.SetGrabbingObject(ingredientOnTable);

            ClearTable();

            currState = State.IDLE;
        }
    }

    private void SwitchIngredient(Ingredient newIngredient)
    {
        if (newIngredient.GetComponent<CursorFollower>())
        {
            newIngredient.GetComponent<CursorFollower>().enabled = false;
        }

        newIngredient.transform.parent = tableTopTransform;
        newIngredient.transform.localPosition = Vector3.zero;

        newIngredient.SetTable(this);
        ingredientOnTable = newIngredient;
    }

    private IngredientSO GetCookedIngredientSO(IngredientSO ingredient)
    {
        // Find cooked version of the ingredient
        foreach (CookableIngredientSO cookableIngredientSO in cookableIngredientSOList)
        {
            if (cookableIngredientSO.rawIngredient == ingredient)
            {
                return cookableIngredientSO.cookedIngredient;
            }
        }

        return null;
    }

    private IngredientSO GetBurntIngredientSO(IngredientSO ingredient)
    {
        // Find burnt version of the ingredient
        foreach (CookableIngredientSO cookableIngredientSO in cookableIngredientSOList)
        {
            if (cookableIngredientSO.cookedIngredient == ingredient)
            {
                return cookableIngredientSO.burntIngredient;
            }
        }

        return null;
    }

    public State GetCurrState()
    {
        return currState;
    }

    public enum State
    {
        IDLE,
        COOKING,
        COOKED,
        BURNT
    }
}
