using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PerceptionState : State
{
    public Fighter Player;
    public Fighter Enemy;
    public string NoInjures;
    public override string GetText()
    {
        var result = new StringBuilder();
        result.AppendLine(base.GetText());
        var visibleinjures = new List<Injure>();
        foreach (var injury in Enemy.GetComponentsInChildren<Injure>())
        {
            if (injury.IsVisible.Check())
                visibleinjures.Add(injury);
        }
        if (!visibleinjures.Any())
        {
            result.AppendLine(NoInjures);
        }
        else
        {
            foreach (var injury in visibleinjures)
            {
                result.AppendLine(injury.Description);
            }
        }
        return result.ToString();
    }

}
