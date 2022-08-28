using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionEqual : BaseCondition
{
    public string Value;
    public override bool Check()
    {
        return Parameter.Value == Value;
          
    }
}
