using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCheck : BaseCondition
{
    public float D = 20f;
    public string MoreThan;
    public string FinalValue;
    public override bool Check()
    {
      
            var random = (int)Random.Range(1, D);
            var check = float.Parse(Parameter.Value) + random;
            var complexity = float.Parse(MoreThan);

            FinalValue = check.ToString();

            return check >= complexity;
      
        return base.Check();
    }

}
