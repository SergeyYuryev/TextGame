using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseText : MonoBehaviour
{
    [TextArea(10, 10)]
    public string Text;


    public ParameterContainer Parameters;

    public virtual string GetText()
    {
         

        var result = Text;
        if (Parameters == null)
            return result;

        foreach (var parameter in Parameters.Parameters)
        {
            result = result.Replace($"{{{parameter.Id}}}", parameter.Value);
        }
        return result;
    }
}
