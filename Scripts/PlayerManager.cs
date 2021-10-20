using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton
    public static PlayerManager instance;
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

    public Agent selectedAgent;

    public void SelectAgent(Agent agent)
    {
        
        DeselectAgent();
        selectedAgent = agent;
        AgentUI.instance.ChangeVisability(true);
        agent.Activate();

    }
    public void DeselectAgent()
    {
        
        if (selectedAgent != null)
        {
            selectedAgent.Deactivate();
            selectedAgent = null;
        }
        AgentUI.instance.ChangeVisability(false);

    }


}
