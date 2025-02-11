using UnityEngine;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance { get; private set; }

    [SerializeField] private InputReader inputReader;
    [SerializeField] private LayerMask interactableLayerMask;

    private IInteractable objectToInteract;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        inputReader.OnInteractAction += TryInteract;
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
}