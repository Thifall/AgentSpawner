using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private int maxValue = 15;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartMoving();
    }
    void Update()
    {
        if(navMeshAgent.remainingDistance <= 0)
        {
            StartMoving();
        }
    }

    void StartMoving()
    {
        navMeshAgent.SetDestination(CalculateNewPatch());
    }

    Vector3 CalculateNewPatch()
    {
        float X = Random.Range(-maxValue, maxValue);
        float Z = Random.Range(-maxValue, maxValue);
        return new Vector3(X, 0, Z);
    }

    


}
