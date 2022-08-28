using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement : BaseText
{
    public State State;
    public Transition Transition;
    public bool IsShowed;
  

  
    private void Start()
    {
   
    }


    public string GetStatement()
    {
        IsShowed = true;

       
        return GetText();
    }
}
