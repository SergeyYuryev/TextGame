using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FightPhase 
{
    public List<FightAction> Actions;

    public void AddAction(params FightAction[] actions)
    {
        if (Actions == null) Actions = new List<FightAction>();

        Actions.AddRange(actions);
    }

    public void ClearActions()
    {
        if (Actions != null)
            Actions.Clear();
    }
}
