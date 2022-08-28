using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCondition : BaseText
{

    public Parameter Parameter;

    public float min;
    public float max;

    public State State;

    public override string GetText()
    {
        

        if(!State.Values.ContainsKey(Parameter.Name))
        {
            
            State.Values[Parameter.Name] = (float.Parse(Parameter.Value) + Random.Range(1, 20)).ToString();
         }

        var param = State.Values[Parameter.Name];

        var value = float.Parse(param);

        if (min <= value && value <= max)

        {
            return base.GetText();

        }


        return null;
    }
}