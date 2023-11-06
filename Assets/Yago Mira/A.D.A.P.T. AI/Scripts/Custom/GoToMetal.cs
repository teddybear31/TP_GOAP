using ADAPT;
using UnityEngine;
using UnityEngine.AI;
public class GoToMetal : Action 
{
    Agent agent;
    NavMeshAgent actual_agent;

    void Awake() 
    { 
        /******DON'T DELETE THIS LINES!!!******/
        agent = gameObject.GetComponent<Agent>();
        //WARNING MESSAGE!
        Debug.Log(" <color=blue> Action: </color> " + actionName + " <color=blue> has preconditions / effects added by code,</color> <color=red> DON'T ADD MORE VIA INSPECTOR!.</color>");
        /************/

        /************/
        //HERE YOU CAN ADD YOUR PRECONDITIONS // EFFECTS
        /************/
        //In case of add preconditions/effects, uncomment the next lines:
        //preconditions_list.Add(ResourceStruct);
        //effects_list.Add(ResourceStruct);
     }

    public override void PerformAction() 
    {
        Debug.Log("Go to metal!");
        agent.agent_states.ModifyStatusItem("onMetalPosition", false); //Initialices the state in case of enter in a loop.

        actual_agent = gameObject.GetComponent<NavMeshAgent>();

        if (target != null && hasTarget) //TARGET EXISTS
        {
            actual_agent.stoppingDistance = stopDistance;
            actual_agent.SetDestination(target.transform.position);
        }

        //Check if Agent NavMesh reach the actual target position
        if (!actual_agent.pathPending && target != null)
        {
            if (actual_agent.remainingDistance <= actual_agent.stoppingDistance)
            {
                if (!actual_agent.hasPath || actual_agent.velocity.sqrMagnitude == 0f)
                {
                    finished = true;
                    agent.agent_states.ModifyStatusItem("onMetalPosition", true);
                }
            }
            else
            {
                finished = false;
            }
        }
    }

}
