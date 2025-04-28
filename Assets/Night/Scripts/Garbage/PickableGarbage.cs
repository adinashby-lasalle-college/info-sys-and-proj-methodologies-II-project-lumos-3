using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableGarbage : PickableItem
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!IsThisObjectPicking)
        {
            //Garbage area
            if (other.GetComponent<GarbageArea>() != null)
            {
                if (gameObject.tag == "Garbage")
                {
                    other.GetComponent<GarbageArea>().DeliverGarbage();
                    Destroy(this.gameObject);
                }
                if (gameObject.tag == "Human")
                {
                    Debug.Log("Drop person into garbage");
                    Destroy(this.gameObject);
                }
            }

            //Kitchen
            if (other.GetComponent<TruckArea>() != null)
            {
                if (gameObject.tag == "Human")
                {
                    other.GetComponent<TruckArea>().DeliverNpc();

                    Destroy(this.gameObject);
                }
            }

            //Stun NPC
            if (other.GetComponent<NPChitbox>() != null)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null && rb.velocity.magnitude > 1f)
                {
                    other.GetComponent<NPChitbox>().Stun();
                }
            }
        }
        
    }
}
