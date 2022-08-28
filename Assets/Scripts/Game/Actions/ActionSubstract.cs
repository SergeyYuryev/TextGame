using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSubstract : BaseAction
{
    public Parameter Parameter;
    public string Value;
    public override void Excute()
    {
        Parameter.Value = (int.Parse(Parameter.Value) - int.Parse(Value)).ToString();
    }
}
