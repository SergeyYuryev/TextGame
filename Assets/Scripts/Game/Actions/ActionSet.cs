using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSet : BaseAction
{
  
    public Parameter[] Parameters;
    public string Value;
    public override void Excute()
    {
        foreach(var Param in Parameters)
        {
            Param.Value = Value;
        }
       
    }
}
