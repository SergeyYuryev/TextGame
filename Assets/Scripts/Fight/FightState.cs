using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : State
{
    public FightWorkFlow WorkFlow;
    public Fighter Owner;
    public Fighter Enemy;
    public Action Action;
    public Weapon Weapon;
    private void Start()
    {
        WorkFlow = GetComponentInParent<FightWorkFlow>();
    }
    protected override void init()
    {
        WorkFlow.BeginNewPhase();
               
        var action = new FightAction {
            Owner = Owner,
            Enemy = Enemy,
            Action = Action,
            Weapon = Weapon,
        };
        WorkFlow.AddAction(action);
        WorkFlow.PreparePhase();
        WorkFlow.EndPhase();
        base.init();
    }
}
