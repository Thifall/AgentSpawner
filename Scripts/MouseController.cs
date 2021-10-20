using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Camera cam;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Agent agent;

            if (Physics.Raycast(ray, out hit))
            {
                agent = hit.collider.GetComponentInParent<Agent>();
                if (agent != null)
                {
                    Debug.Log("trafiono w " + agent);
                    PlayerManager.instance.SelectAgent(agent);
                }
                else
                {
                    Debug.Log("trafiono w nic");
                    PlayerManager.instance.DeselectAgent();
                }
            }
        }
    }


}
