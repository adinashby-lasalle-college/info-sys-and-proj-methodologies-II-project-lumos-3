using UnityEngine;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance { get; private set; }

    [SerializeField] private LayerMask interactableLayerMask;

    private InputReader inputReader;
    private Grabbable grabbingObject;

    public bool IsGrabbing { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        inputReader = GetComponent<InputReader>();

        inputReader.OnInteractAction += TryInteract;
    }

    private void TryInteract(object sender, System.EventArgs e)
    {
        // Try interact with all interactable objects under mouse cursor
        float distance = 100f;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distance;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(Camera.main.transform.position, mousePos, distance);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.transform.TryGetComponent(out IInteractable interactableObj))
            {
                interactableObj.Interact();
            }
        }
    }

    public Grabbable GetGrabbingObject()
    {
        return grabbingObject;
    }

    public void SetGrabbingObject(Grabbable grabbableObject)
    {
        grabbingObject = grabbableObject;
        IsGrabbing = true;

        grabbingObject.GetComponentInChildren<Collider>().enabled = false;
    }

    public void ClearGrabbingObject()
    {
        grabbingObject.GetComponentInChildren<Collider>().enabled = true;

        grabbingObject = null;
        IsGrabbing = false;
    }
}