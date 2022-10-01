using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkflowTransition : Transition

{
    public Workflow ParentWorkflow;
   
    public Workflow NextWorkflow;


    

    public override void Transit()
    {

        Nextstate = NextWorkflow.State;
        ParentState = ParentWorkflow.GetEntryPoint();
 

        scene.CurretWorkflow = NextWorkflow;

        var currentstate = NextWorkflow.GetEntryPoint();
        currentstate.Entry = this;

        scene.CurretWorkflow.InitWorkFlow();

        scene.CurretWorkflow.SetState(currentstate);


        currentstate.InitState(ParentWorkflow.State);

       
    }

}
