using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransitionCondition : MonoBehaviour
{
    public Transition Parent;
    public Parameter Parameter;
    public State NextState;
    public float min;
    public float max;
    public bool Check() 
    {
        ParameterResult pr = Parent.ParentState.Values.FirstOrDefault(x => x.Key == Parameter.Id);
        if (pr == null)
        {
            pr = new ParameterResult { Key = Parameter.Id, Value = (float.Parse(Parameter.Value) + Random.Range(1, 20)).ToString() };
            Parent.ParentState.Values.Add(pr);
        }


        var value = float.Parse(pr.Value);

        if (min <= value && value <= max)

        {
            return true;

        }


        return false;
    }
}
