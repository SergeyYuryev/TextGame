using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public FightAI AI;
    public string Side;
    public Parameter Agility;
    public Parameter Strength;
    public Parameter Will;
    public Parameter Name;
    public Body Body;
    public Parameter MaxEnergy;
    public Parameter CurentEnergy;

    public float PhaseEnergy = 5;
    internal virtual FightAction[] GetActions()
    {
        if (AI == null)
            return null;

        return AI.GetActions();
    }
    public void BeginPhase()
    {
        CurentEnergy.floatValue = CurentEnergy.floatValue + PhaseEnergy;

        if (CurentEnergy.floatValue > MaxEnergy.floatValue)
            CurentEnergy.floatValue = MaxEnergy.floatValue;
    }
    public void EndPhase()
    {

    }

    internal void Init()
    {
        var commonhealth =( Agility.floatValue )* ( Strength.floatValue);
        foreach(var part in Body.Parts)
        {
            part.Health = part.Durability * commonhealth;
        }
        var maxenergy = (Agility.floatValue) * (Strength.floatValue);
        MaxEnergy.floatValue = maxenergy;
        CurentEnergy.floatValue = maxenergy;
      
    }
    public float GetEnergyLevel()
    {
        return CurentEnergy.floatValue / MaxEnergy.floatValue;
    }

}
