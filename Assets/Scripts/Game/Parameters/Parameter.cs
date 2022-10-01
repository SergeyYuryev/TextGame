using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter : MonoBehaviour
{
    public string Id;
    public string Name;
    public string Value ;

    public int intValue
    {
        get
        {
            return int.Parse(Value);
        }
        set
        {
            Value = value.ToString();
        }
    }
    public float floatValue
    {
        get
        {
            return float.Parse(Value);
        }
        set
        {
            Value = value.ToString();
        }
    }
}
