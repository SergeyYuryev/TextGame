using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCheck : BaseCondition
{

    public string MoreThan;
    public string FinalValue;
    public override bool Check()
    {
      
            var random = +Random.Range(1, 20);
            var check = float.Parse(Parameter.Value) + random;
            var complexity = float.Parse(MoreThan);

            FinalValue = random.ToString();

            return check >= complexity;
      
        return base.Check();
    }

}
