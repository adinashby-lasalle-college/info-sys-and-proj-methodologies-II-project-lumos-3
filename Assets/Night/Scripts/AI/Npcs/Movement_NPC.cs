using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement_NPC : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float moveDuration = 5f;
    [SerializeField] float idleDuration = 5f;
    [SerializeField] float walkRadius = 10f;

    float timer = 0f;
    bool isWalking = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ChooseNewDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (detecting)
        {
            agent.ResetPath();
            if (timer >= detectingDuration)
            {
                timer = 0f;
                isWalking = true;
                detecting = false;
                agent.ResetPath(); // Stop moving
            }
        }
        else if (isWalking)
        {
            if (timer >= moveDuration)
            {
                timer = 0f;
                isWalking = false;
                agent.ResetPath(); // Stop moving
            }
        }
        else
        {
            if (timer >= idleDuration)
            {
                timer = 0f;
                isWalking = true;
                ChooseNewDestination(); // Pick a new random location
            }
        }
    }

    //Randomly moving
    void ChooseNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, walkRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);

        }
    }

    //Detect Player
    public bool detecting;
    float detectingDuration = 5f;

}
