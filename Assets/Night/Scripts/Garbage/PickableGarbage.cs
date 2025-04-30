using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickableGarbage : PickableItem
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Animation animation = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>();
        if(!IsThisObjectPicking)
        {
            //Garbage area
            if (other.GetComponent<GarbageArea>() != null)
            {
                if (gameObject.tag == "Garbage")
                {
                    other.GetComponent<GarbageArea>().DeliverGarbage();
                    Destroy(this.gameObject);
                    animation.Play();
                }
                if (gameObject.tag == "Human")
                {
                    other.GetComponent<GarbageArea>().DeliverNpc();
                    Destroy(this.gameObject);
                    animation.Play();
                }
            }

            //Kitchen
            if (other.GetComponent<TruckArea>() != null)
            {
                if (gameObject.tag == "Human")
                {
                    other.GetComponent<TruckArea>().DeliverNpc();

                    Destroy(this.gameObject);
                    animation.Play();
                }
            }

            //Stun NPC
            if (other.GetComponent<NPChitbox>() != null)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null && rb.velocity.magnitude > 1f)
                {
                    other.GetComponent<NPChitbox>().Stun();
                    animation.Play();
                }
            }
        }
        
    }
}
