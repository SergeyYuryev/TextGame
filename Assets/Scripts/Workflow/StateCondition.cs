using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateCondition : StateText
{

    public Parameter Parameter;

    public float min;
    public float max;
 
    public override string GetText()
    {

        ParameterResult pr = State.Values.FirstOrDefault(x => x.Key == Parameter.Id);
        if (pr == null)
        {
            pr = new ParameterResult { Key = Parameter.Id, Value = (float.Parse(Parameter.Value) + Random.Range(1, 20)).ToString() };
            State.Values.Add(pr);
         }

     
        var value = float.Parse(pr.Value);

        if (min <= value && value <= max)

        {
            return base.GetText();

        }


        return null;
    }
}