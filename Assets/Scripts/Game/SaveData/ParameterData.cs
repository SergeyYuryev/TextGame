using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
[Serializable]
public class ParameterData
{
    [DataMember]
    public string path;

    [DataMember]
    public string value;
}
