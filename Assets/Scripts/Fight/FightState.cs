using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : State
{
    public FightWorkFlow WorkFlow;
    public FightAction FightAction;

    public Weapon Weapon;
    private void Start()
    {
        WorkFlow = GetComponentInParent<FightWorkFlow>();
    }
    protected override void init()
    {
        WorkFlow.BeginNewPhase();
               
      
       
        WorkFlow.AddActions(FightAction);
       WorkFlow.PreparePhase();
        WorkFlow.EndPhase();

        Text = WorkFlow.FightLog.ToString();
        base.init();
    }
}
