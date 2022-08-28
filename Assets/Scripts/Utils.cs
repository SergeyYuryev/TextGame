using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils  
{
    public static string GetFilePath(string filename)
    {
        string destination = Application.persistentDataPath + "/" + filename;
        return destination;
    }
}
