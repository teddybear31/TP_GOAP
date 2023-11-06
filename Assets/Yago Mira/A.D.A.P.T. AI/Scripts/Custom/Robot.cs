using ADAPT;
using UnityEngine;
public class Robot : Agent 
{
    new void Start() //DON'T MODIFY ANY LINE OF THIS FUNCTION!!!
    {
        AddGoals();
        /************/
        base.Start(); //DON'T DELETE THIS LINE!!!
        /************/
        ManageStates();

        agent.baseOffset = 0;
        agent.speed = 1;
    }

    public void AddGoals()
    {
        InventoryResource levelHealth = (new InventoryResource("healthAircraft", 100, 50, 100, true));
        InventoryResource levelMetal = (new InventoryResource("metal", 30, 30, 200, true));
        StatusResource goToMetal = (new StatusResource("onMetalPosition", true, 50));

        goals.Add(new Goal(levelHealth, false));
        goals.Add(new Goal(levelMetal, false));
        goals.Add(new Goal(goToMetal, false));

        //If you want to add some goals can use the next lines (an change the ResourceType):
        //InventoryResource goal_1 = (new InventoryResource("minedGold", 105.0f, 15, 106, false));
        //goals.Add(new Goal(goal_1, false));
    }

    public void ManageStates() 
    { 
        //If you want to add some states can use the next lines:
        agent_states.AddInventoryItem("metal", 0); /*For local agent states*/
        global_states.AddInventoryItem("healthAircraft", 30); /*For global agent states*/
        agent_states.AddStatusItem("onMetalPosition", false);

    }

}
