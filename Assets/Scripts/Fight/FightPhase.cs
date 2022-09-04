using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FightPhase 
{
    public List<FightAction> Actions;

    public void AddAction(FightAction action)
    {
        if (Actions == null) Actions = new List<FightAction>();

        Actions.Add(action);
    }

    public void ClearActions()
    {
        if (Actions != null)
            Actions.Clear();
    }
}
