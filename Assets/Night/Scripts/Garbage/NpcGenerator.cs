using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGenerator : MonoBehaviour
{
    public GameObject NPC;
    public Transform spawnPointA;
    public Transform spawnPointB;
    private void OnEnable()
    {
        Spawn();
    }

    public void Spawn()
    {
        int spawnCount = Random.Range(1, 3); // 1-2 npcs

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnPointA.position.x, spawnPointB.position.x),
                Random.Range(spawnPointA.position.y, spawnPointB.position.y)
            );

            Instantiate(NPC, randomPosition, Quaternion.identity);
        }
    }
}
