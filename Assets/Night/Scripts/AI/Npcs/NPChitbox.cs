using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPChitbox : MonoBehaviour
{
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject[] NPCComponent;

    [SerializeField] GameObject NPCBody;
    [SerializeField] AudioClip HitEff;

    public void Stun()
    {
        foreach (var npc in NPCComponent)
        {
            Destroy(npc.gameObject);
        }
        Instantiate(NPCBody, NPC.transform.position, NPC.transform.rotation);
        AudioPlayer player = NPC.GetComponent<AudioPlayer>();
        player.PlaySound(0);
        StartCoroutine(DestroyWhole());
    }

    IEnumerator DestroyWhole()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(NPC);
    }
}
