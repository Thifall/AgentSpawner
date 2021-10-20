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
        //trzymałbym to w polu i nazwałbym je jakoś adekwatniej do tego czym jest, bo tera to nie wiadomo co to za mesh zmieniasz
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
    
    public void RevieveSingleDamagePoint()
    {
        DecreasedHpValue();
        UpdateHealthBar();
        CheckForDeath();
    }
    
    public void DecreasedHpValue()
    {
        hp--;
    }
    
    public void UpdateHealthBar()
    {
        if (isActive)
        {
            AgentUI.instance.ChangeHealthBar(hp);
        }
    }
    
    public void CheckForDeath()
    {
        if (hp <= 0)
        { 
            DestroyAgent();
        }
    }
    
     //nazywa się DecreaseHP, a robi parę innych rzeczy :)
     //Przerobiłbym to delikatnie na coś w takim stylu jak powyżej
     
    //public void DecreasedHP()
    //{
    //    hp--;
    //    if (isActive)
    //    {
    //        AgentUI.instance.ChangeHealthBar(hp);
    //    }
    //    if (hp <= 0)
    //    { 
    //        DestroyAgent();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        DecreasedHP();
    }


}
