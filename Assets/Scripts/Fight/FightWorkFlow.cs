using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightWorkFlow : Workflow
{
    public Fighter[] Fighters;
    public FightPhase Current;


    private FightPhase GetCurrentPhase()
    {
        if (Current == null)
            Current = new FightPhase();

        return Current;
    }
    public void AddAction(FightAction action)
    {

        var phase = GetCurrentPhase();

        Current.AddAction(action); 
    }

    internal void BeginNewPhase()
    {
        var phase = GetCurrentPhase();
        phase.ClearActions();
    }

    internal  void EndPhase()
    {
      
    }

    internal  void PreparePhase()
    {
        
    }
}
