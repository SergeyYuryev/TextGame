using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParameterContainer : MonoBehaviour
{
    public Parameter[] Parameters;

    public Parameter Find(string name) 
    {
        if (Parameters == null)
            return null;

        return Parameters.FirstOrDefault(x => x.Id == name);
    }

}
