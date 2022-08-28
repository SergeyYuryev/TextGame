using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class ParameterResult
{
    public string Key;
    public string Value;
}
public class State : BaseText
{
    public Transition Entry;

    public StateAction[] StartActions;
    public State PreviousState;

    public StateText[] Conditions;
    public List<ParameterResult> Values;

    public string Title; 
    public Transition[] Transitions;

    private void Start()
    {
    
    }

    private void init()
    {
        Conditions = GetComponentsInChildren<StateText>();
        Values = new List<ParameterResult>();
        foreach (var condition in Conditions)
        {
            condition.State = this;

            if (condition.Parameters == null)
                condition.Parameters = this.Parameters;
        }
    }


    public override string GetText()
    {
        init();
        var result = new StringBuilder();

        result.AppendLine(base.GetText());

        if (Conditions != null)
        {
            foreach (var c in Conditions)
            {
                var text = c.GetText();

                if (!string.IsNullOrEmpty(text))
                    result.AppendLine(text);
            }
        }

        return result.ToString();
    }

    internal void Exit()
    {
        Values = new List<ParameterResult>();
    }

    public virtual void InitState(State prvious)
    {
        PreviousState = prvious;
       
    }

    public virtual Transition[] GetTransitions()
    {
        var result = new List<Transition>();
        if (Transitions != null)
        {
            result.AddRange(Transitions);
        }

        result.AddRange(GetComponentsInChildren<Transition>());

        return result.
            Where(x =>x != null && x.IsAllow())
            .Distinct()
            .ToArray();
    }

    public void StartAction()
    {
       if(StartActions !=null)

        foreach (var startaction in StartActions)
        {
            if (startaction != null)
            {
                startaction.Excute();
            }
        }
    }


    //public virtual bool IsAllow()
    //{

    //    foreach (var condition in Conditions)
    //    {
    //        var Param = Parameters.Parameters.FirstOrDefault(x => x.Id == condition.Name);

    //        if (Param == null)
    //            continue;

    //        if (condition.Operation == "equal")
    //        {
    //            if (Param.Value != condition.Value)
    //                return false;
    //        }

    //        if (condition.Operation == "check")
    //        {
    //            var random = +Random.Range(1, 20);
    //            var check = float.Parse(Param.Value) + random;
    //            var complexity = float.Parse(condition.Value);

    //            condition.FinalValue = random.ToString();

    //            return check >= complexity;
    //        }
    //    }
    //    return true;
    //}

}
