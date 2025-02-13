using UnityEngine;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance { get; private set; }

    [SerializeField] private LayerMask interactableLayerMask;

    private InputReader inputReader;
    private IInteractable objectToInteract;
    private Vector2 cursorPos;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        inputReader = GetComponent<InputReader>();

        inputReader.OnInteractAction += TryInteract;
    }

    private void FixedUpdate()
    {
        //cursorPos = Camera.main.WorldToScreenPoint(inputReader.GetCursorPos());
        //Debug.Log(cursorPos);
    }

    private void TryInteract(object sender, System.EventArgs e)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 100f;

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            // If a mouse pointer is on interactable objects, get ready to interact
            if (hit.transform.TryGetComponent(out IInteractable detectedObj))
            {
                detectedObj.Interact();
            }
        }
    }

    public Vector2 GetCursorPos()
    {
        return Camera.main.ScreenToWorldPoint(cursorPos);
    }
}