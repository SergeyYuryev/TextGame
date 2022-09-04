using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workflow : GameMonoBehavior, IWorkflow

{
    public string Id;
 
    public State State;

    public Transition[] DefaultTransitions;
    public State GetState (){ 
        
    
            if(State == null)
            {
                State = GetEntryPoint();
            }

            return State; 
         
    }

    public State GetEntryPoint() 
    {
        if (DefaultTransitions != null)
        {
            foreach (var Transition in DefaultTransitions)
            {
                if (Transition.IsAllow())
                {
                    Transition.Transit();
                    return Transition.Nextstate;
                }
            }
        }

        return State;
    }

   

    public void SetState(State state)
    {
        State = state;
        state.StartAction();
        scene.Controller.InitState(State);
    }
}
