using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public string Name;
    public Statement[] Statements;
    private void Start()
    {
        Statements = GetComponentsInChildren<Statement>();
    }

}
