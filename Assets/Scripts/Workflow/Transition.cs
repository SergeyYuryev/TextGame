using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Transition : GameMonoBehavior
{
    private void Start()
    {
        if (string.IsNullOrEmpty(Id))
        {
            Id = DateTime.UtcNow.Ticks.ToString();
            Thread.Sleep(1);
        }
    }
    public int SpendMinutes = 1;
    public string Id;
    public string ActionName;
    [TextArea]
    public string Description;
    public State ParentState;
    public State Nextstate;
   
    public bool IsShow;
    public bool ShowOnce;

  

    public bool IsAllow()
    {
        if (ShowOnce && IsShow)
            return false;
        var conditions = GetComponents<BaseCondition>();
        foreach(var condition in conditions)
        {
            if (condition == null)
                continue;

            if (!condition.Check())
                return false;
        }

        return true;
    }

    public virtual  void Transit() {
        var actions = GetComponents<BaseAction>();


        foreach (var startaction in actions)
        {
            if (startaction != null)
            {
                startaction.Excute();
            }
        }
        IsShow = true;
        Nextstate.Entry = this;
        scene.CurretWorkflow.SetState(Nextstate);
        Nextstate.InitState(ParentState);
        scene.TimeController.addTime(SpendMinutes);
    }

   

}
