using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableGarbage : PickableItem
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        //Garbage area
        if (other.GetComponent<GarbageArea>() != null)
        {
            if(gameObject.tag == "Garbage")
            {
                other.GetComponent<GarbageArea>().DeliverGarbage();
            }
            if (gameObject.tag == "Human")
            {
                Debug.Log("Drop person into garbage");
            }
            Destroy(this.gameObject);
        }

        //Kitchen
        if (other.GetComponent<GarbageArea>() != null)
        {
            if (gameObject.tag == "Human")
            {
                Debug.Log("Drop person into kitchen");
            }
            Destroy(this.gameObject);
        }
    }
}
