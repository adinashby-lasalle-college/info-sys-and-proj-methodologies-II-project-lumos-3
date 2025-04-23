using UnityEngine;

public abstract class Grabbable : MonoBehaviour
{
    public abstract ObjectType GetObjectType();
}

public enum ObjectType
{
    INGREDIENT_READY,
    BUN,
    CUTTABLE,
    COOKABLE,
    SAUCE,
    GARBAGE
}