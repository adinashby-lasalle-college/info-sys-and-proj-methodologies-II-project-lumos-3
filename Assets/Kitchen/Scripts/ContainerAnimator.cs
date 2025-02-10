using UnityEngine;

public class ContainerAnimator : MonoBehaviour
{
    public void PlayOpenAnimation(Container container)
    {
        // Play animation once it's ready to interact
        Debug.Log("Open the cap of " + container.name);
    }

    public void PlayCloseAnimation(Container container)
    {
        Debug.Log("Close the cap of " + container.name);
    }
}
