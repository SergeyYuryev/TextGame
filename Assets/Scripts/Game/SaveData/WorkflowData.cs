using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
[Serializable]
public class WorkflowData
{
    [DataMember]
    public string name;

    [DataMember]
    public string statename;
}
