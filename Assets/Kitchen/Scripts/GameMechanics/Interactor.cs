using UnityEngine;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance { get; private set; }

    [SerializeField] private LayerMask interactableLayerMask;

    private Grabbable grabbingObject;

    public bool IsGrabbing { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        InputReader.Instance.OnInteractAction += TryInteract;
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
        ClearGrabbingObject();

        grabbingObject = grabbableObject;
        IsGrabbing = true;

        grabbingObject.GetComponentInChildren<Collider>().enabled = false;
    }

    public void ClearGrabbingObject()
    {
        if (grabbingObject)
        {
            grabbingObject.GetComponentInChildren<Collider>().enabled = true;

            grabbingObject = null;
            IsGrabbing = false;
        }
    }
}