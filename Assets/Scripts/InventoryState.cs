using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState : State
{
    public Inventory Inventory;
    public Transition ExitTransition;
    public BaseGameObject inventorybuttonPrefab;
    public GameController GameController;

    public override void InitState(State previous)
    {
        base.InitState(previous);
        ExitTransition.Nextstate = previous;
    }
    public override Transition[] GetTransitions()
    {
        var transitions = new List<Transition>();


        //var money = Inventory.GetItem("money");
        //if (money != null)
        //{
        //    MoneyValue.text = money.Count.ToString();
        //}
        //else { MoneyValue.text = "0"; }

        for (var i =0; i < Inventory.Items.Count; i++)
        {
            var item = Inventory.Items[i];
            var count = item.GetCount();
            var actionname = item.Name;
            if (count > 1)
            {
                actionname = $"{actionname} - {count}";
            }


            var wt = this.gameObject.AddComponent<WorkflowTransition>();

            wt.Id = $"item_{i}";
            wt.ActionName = actionname;
            wt.ParentState = this;
            wt.ParentWorkflow = Inventory.Workflow;
            wt.NextWorkflow = item.workflow;
    

            transitions.Add(wt) ; 
        }


        transitions.Add(ExitTransition);
        return transitions.ToArray();
    }

}
