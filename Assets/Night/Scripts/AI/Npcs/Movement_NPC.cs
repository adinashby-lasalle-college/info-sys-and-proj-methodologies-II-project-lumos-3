using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using UnityEngine.AI;

public class Movement_NPC : MonoBehaviour
{
    NavMeshAgent agent;
    public float moveDuration = 5f;
    public float idleDuration = 5f;
    public float walkRadius = 10f;

    float timer = 0f;
    bool isWalking = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateController = GetComponent<NPCController>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ChooseNewDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isWalking)
        {
            if (!disturbing)
            {
                if (timer >= moveDuration || detecting)
                {
                    timer = 0f;
                    isWalking = false;
                    agent.ResetPath(); // Stop moving
                }
            }
            else
            {
                if (timer >= moveDuration)
                {
                    timer = 0f;
                    isWalking = false;
                    agent.ResetPath(); // Stop moving
                }
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
    [SerializeField] float detectingDuration = 5f;

    //Disturb
    bool disturbing = false;
    NPCController stateController;

    public void DisturbNPC()
    {
        disturbing = true;
        stateController.currentState.SwitchState(stateController);
        idleDuration = stateController.D_IdleDur;
        moveDuration = stateController.D_MoveDur;
        walkRadius = stateController.D_MoveRadius;
    }

    public void KnockDownNPC()
    {
        
    }

    void NPCAwake()
    {
        disturbing = false;
    }
}
