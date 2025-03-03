using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane + 1));

        transform.position = mousePos;
    }
}
