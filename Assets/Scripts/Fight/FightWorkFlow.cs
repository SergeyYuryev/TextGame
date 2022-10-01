using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class FightWorkFlow : Workflow
{
    public Fighter[] Fighters;
    public FightPhase Current;

    public StringBuilder FightLog;

    private void Start()
    {
        FightLog = new StringBuilder();
    }

    private FightPhase GetCurrentPhase()
    {
        if (Current == null)
            Current = new FightPhase();

        return Current;
    }
    public void AddActions(params FightAction[] action)
    {

        var phase = GetCurrentPhase();

        Current.AddAction(action);
    }

    internal void BeginNewPhase()
    {
        var phase = GetCurrentPhase();
        phase.ClearActions();
        foreach(var fighter in Fighters)
        {
            fighter.BeginPhase();
        }
        FightLog.Clear();
    }

    internal void EndPhase()
    {
        foreach (var action in Current.Actions.OrderByDescending(x => x.Sequence))
        {
            action.Calculate(FightLog);
        }

        foreach (var fighter in Fighters)
        {
            fighter.EndPhase();
        }
    }

    internal void PreparePhase()
    {
        foreach (var fighter in Fighters)
        {
            var actions = fighter.GetActions();
            if (actions != null && actions.Any())
            {
                AddActions(actions);
            }

        }

        foreach (var action in Current.Actions)
        {
            action.Sequence = action.Owner.Agility.intValue + Random.Range(1, 20);
        }
    }

    public override void InitWorkFlow()
    {

        foreach (var figher in Fighters)
        {
            figher.Init();
        }

    }
}
