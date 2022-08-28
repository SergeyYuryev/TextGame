using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string Id;
    public string Name;
    public ParameterContainer Parameters;

    public string Names;
    public int GetCount() {
        if (Parameters == null)
            return 1;

        var parameter = Parameters.Find("count");

        if (parameter == null)
            return 1;

        return int.Parse(parameter.Value);
    }

    public Workflow workflow;

 
}
