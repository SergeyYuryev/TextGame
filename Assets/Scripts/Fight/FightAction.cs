using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  enum Action
{
    Push,
    Hit,
    Dodge,
    Block,
    Jump,


}
public enum Weapon
{
    Hand,
    Leg,
    Head,
        
}
[Serializable]
public class FightAction 
{
    public Fighter Owner;
    public Fighter Enemy;
    public Action Action;
    public Weapon Weapon;
    
}
