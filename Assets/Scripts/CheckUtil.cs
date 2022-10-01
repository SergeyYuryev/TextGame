using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckUtil
{
    public static T GetRandom<T>(T[] items)  
    {
        if (items == null)
            return default(T);
        if (!items.Any())
            return default(T);

        return items[Random.Range(0, items.Length - 1)];
    }
    public static int D(int d)
    {
        var result = Random.Range(1, d);
        if(result == 1)
        {
            return -result - D(d);
        }

        if(result == d)
        {
            result = d + D(d);
        }

        return result;
    }

}
