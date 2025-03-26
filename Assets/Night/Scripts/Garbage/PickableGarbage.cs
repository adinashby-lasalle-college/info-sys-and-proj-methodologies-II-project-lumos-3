using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableGarbage : PickableItem
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<GarbageArea>() != null)
        {
            other.GetComponent<GarbageArea>().DeliverGarbage();
            Destroy(this.gameObject);
        }
    }
}
