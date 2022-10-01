using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public int D;
    public CheckOption[] Options;
    public GameObject GetRandomOption()
    {
        var result = Random.Range(1, D);
        foreach(var option in Options)
        {
            if (option.From >= result && result <= option.To)
                return option.Reference;
        }
        return null;
    }

}
