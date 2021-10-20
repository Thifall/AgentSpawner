using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private int hp = 3;
    private bool isActive = false;
    public void Activate()
    {
        ChangeColor(Color.green);
        isActive = true;
        AgentUI.instance.ChangeActiveAgent(name);
        AgentUI.instance.ChangeHealthBar(hp);
    }

    public void Deactivate()
    {
        ChangeColor(Color.blue);
        isActive = false;
    }
    private void ChangeColor(Color color)
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material.color = color;
        }

    }

    public void DestroyAgent()
    {
        AgentManager.instance.DecreasedAgentsNumber();
        if(isActive)
        {
            AgentUI.instance.ChangeVisability(false);
        }
        Destroy(gameObject);
    }

    public void DecreasedHP()
    {
        hp--;
        if (isActive)
        {
            AgentUI.instance.ChangeHealthBar(hp);
        }
        if (hp <= 0)
        { 
            DestroyAgent();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        DecreasedHP();
    }


}
