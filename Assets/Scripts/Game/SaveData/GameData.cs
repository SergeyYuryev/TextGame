using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
[Serializable]
public class GameData
{
    [DataMember]
    public string currentWorkflow;

    [DataMember]
    public WorkflowData[] workflows;


    [DataMember]
    public ParameterData[] parameters;
}
