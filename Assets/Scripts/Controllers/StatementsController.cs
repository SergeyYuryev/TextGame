using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StatementsController : MonoBehaviour
{
    public Player Player;


    public string GetStatements(Transition transition)
    {
        var team = Player.Team;
        if (team == null)
            return string.Empty;
        var result = new StringBuilder();
        foreach (var person in team.Members)
        {
            var statements = person.Statements.Where(x => x.Transition == transition && !x.IsShowed);

            foreach (var statement in statements)
            {
                result.AppendLine(statement.GetStatement());
            }

        }

        return result.ToString();
    }
    public string GetStatements(State state)
        {
        var team = Player.Team;
        if (team == null)
            return string.Empty;
        var result = new StringBuilder();
        foreach (var person in team.Members)
        {
            var statements = person.Statements.Where(x => x.State == state && !x.IsShowed);

            foreach (var statement in statements)
            {
                result.AppendLine(statement.GetStatement());
            }

        }

        return result.ToString();
    }
    
}
