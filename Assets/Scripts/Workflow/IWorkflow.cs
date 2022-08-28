using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkflow 
{
    void SetState(State state);
    State GetState();
 
}
