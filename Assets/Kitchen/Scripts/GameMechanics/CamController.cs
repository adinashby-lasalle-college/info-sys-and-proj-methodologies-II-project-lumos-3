using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private float speed = 3f;

    private float minZ = -1.3f;
    private float maxZ = 0.6f;

    void Update()
    {
        float currX = transform.position.x;
        float currY = transform.position.y;

        Vector3 moveDir = new Vector3(0f, 0f, inputReader.GetZInput());
        transform.position += moveDir * speed * Time.deltaTime;

        // Block camera to move further than the limited Z
        if (transform.position.z < minZ)
        {
            transform.position = new Vector3(currX, currY, minZ);
        }

        if (transform.position.z > maxZ)
        {
            transform.position = new Vector3(currX, currY, maxZ);
        }
    }
}
