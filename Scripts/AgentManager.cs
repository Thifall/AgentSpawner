using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public GameObject agentPrefab;

    [SerializeReference] private float minSpawnTime = 2;
    [SerializeReference] private float maxSpawnTime = 10;
    [SerializeReference] private int maxAgentsNumber = 30;

    private float nextSpawnTime;
    private int currentAgentsNumber = 0;
    private bool coroutinesRunning = true;

    public Transform[] spawnPositions;

    #region Singleton
    public static AgentManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance Exist");
            Destroy(this);
        }
    }
    #endregion
    private void Start()
    {
        StartCoroutine(SpawnCoroutines());
    }

    IEnumerator SpawnCoroutines()
    {
        for( ; ; )
        {
            if (currentAgentsNumber < maxAgentsNumber)
            {
                CreateAgent();
                nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                Debug.Log(currentAgentsNumber);
                yield return new WaitForSeconds(nextSpawnTime);
            }
            else
            {
                Debug.Log("Za ifemm");
                coroutinesRunning = false;
                yield break;
            }    
        }
    }

    IEnumerator ContinueCoroutines()
    {
        coroutinesRunning = true;
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Debug.Log($"czekamy se");
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

        yield return StartCoroutine(SpawnCoroutines());
    }

    private void CreateAgent()
    {
        int i = Random.Range(0, spawnPositions.Length);
        Instantiate(agentPrefab, spawnPositions[i].position, spawnPositions[i].rotation);
        currentAgentsNumber++;
    }

    public void DecreasedAgentsNumber()
    {
        currentAgentsNumber--;
        CheckCoroutines();
    }

    public void CheckCoroutines()
    {
        if (!coroutinesRunning && currentAgentsNumber < maxAgentsNumber)
        {
            StartCoroutine(ContinueCoroutines());
        }
    }

}
