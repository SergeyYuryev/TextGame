using System.Linq;
using UnityEngine;

public class FightAI : MonoBehaviour
{
    public Fighter Person;
    public FightWorkFlow Fight;
    public Weapon Weapon;
    public FightAction[] Actions;
    private void Start()
    {
        Actions = GetComponents<FightAction>();

    }
    internal FightAction[] GetActions()
    { 

        var enemy = Fight.Fighters.FirstOrDefault(x => x.Side != Person.Side);

        if (enemy == null)
            return null;

        foreach (var action in Actions)
        {
            action.Owner = Person;
            action.Enemy = enemy;
        }

        var randomaction = Actions[Random.Range(0, Actions.Length - 1)];
        return new FightAction[]
        {
            randomaction
        };
    }

  
}
