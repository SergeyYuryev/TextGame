using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCondition : MonoBehaviour
{
    public Parameter Parameter;
 
    public virtual bool Check()
    {
        return false;
    }
}
