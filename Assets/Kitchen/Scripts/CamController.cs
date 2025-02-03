using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private float speed = 3f;

    void Update()
    {
        Vector3 moveDir = new Vector3(0f, 0f, inputReader.GetZInput());
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
