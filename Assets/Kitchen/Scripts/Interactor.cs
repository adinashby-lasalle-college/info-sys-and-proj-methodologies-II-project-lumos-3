using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private LayerMask interactableLayerMask;

    private IInteractable objectToInteract;

    private void Start()
    {
        inputReader.OnInteractAction += TryInteract;
    }

    private void Update()
    {
        DetectObject();
    }

    // Detect object through mouse pointer
    private void DetectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 100f;

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            // If a mouse pointer is on interactable objects, get ready to interact
            if (hit.transform.TryGetComponent(out IInteractable interactableObj))
            {
                objectToInteract = interactableObj;
                objectToInteract.ReadyToInteract();
            }
        }
    }

    private void TryInteract(object sender, System.EventArgs e)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 100f;

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            // If a mouse pointer is on interactable objects, get ready to interact
            if (hit.transform.TryGetComponent(out IInteractable interactableObj))
            {
                objectToInteract.Interact();
            }
        }       
    }
}
