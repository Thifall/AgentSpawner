using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentUI : MonoBehaviour
{

    #region Singleton
    public static AgentUI instance;
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

    public GameObject agentUI;
    [SerializeField]private HealthBar healthBar;
    public Text agentName;
    public void ChangeVisability(bool value)
    {
        Debug.Log(value);
        agentUI.SetActive(value);
    }

    public void ChangeActiveAgent(string name)
    {
        agentName.text = name;
    }

    public void ChangeHealthBar(int value)
    {
        healthBar.SetHealth(value);
    }
}
