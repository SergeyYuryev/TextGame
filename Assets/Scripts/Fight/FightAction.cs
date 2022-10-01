using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;




[Serializable]
public class FightAction : MonoBehaviour
{
    public Fighter Owner;
    public Fighter Enemy;
    public eAction Action;
    public Weapon Weapon;
    public int Sequence;
    public float EnergyCost;
    public PartHit[] Hits;
    public virtual void Calculate(StringBuilder FightLog)
    {
        var owneragility = Owner.Agility.floatValue + CheckUtil.D(20);
        var targetagility = Enemy.Agility.floatValue + CheckUtil.D(20);
        var damagebonus = 0f;
        Part hitpart = null;
        if (Hits == null || !Hits.Any())
        {
            var hit = Enemy.Body.Check.GetRandomOption();
            hitpart = hit.GetComponent<Part>();
        }
        else
        {
            var hit = CheckUtil.GetRandom(Hits);
            hitpart = hit.Part;
            owneragility = owneragility - hit.PenaltyHit;
            damagebonus = hit.DamageBonus;
        }

        if (owneragility < targetagility)
        {
            FightLog.AppendLine($"{Owner.Name.Value} пытаеться ударить {Weapon} но промахиваеться");

        }
        else
        {
         
            

            var realdamage = CalculateDamage(Weapon.BaseDamage+damagebonus, hitpart);

            if (realdamage > 0)
            {
                hitpart.Health = hitpart.Health - realdamage;

                FightLog.AppendLine($"{Owner.Name.Value} бьет {Weapon.Name}  в {hitpart.Name} и наносит повреждение {realdamage}");

                if (hitpart.Health <= 0)
                {
                    FightLog.AppendLine($"{hitpart.Name} выходит из строя");
                }
            }
        }

        Owner.CurentEnergy.floatValue = Owner.CurentEnergy.floatValue - EnergyCost;
    }
    public float CalculateDamage(float basedamage, Part hitpart)
    {
        var hitstrength = Owner.Strength.floatValue * Owner.GetEnergyLevel() + CheckUtil.D(20);
        var hitprotection = Enemy.Strength.floatValue * Enemy.GetEnergyLevel() + CheckUtil.D(10);
        var damage = basedamage + hitstrength - hitprotection;



        var vulnerability = hitpart.Damages.FirstOrDefault(x => x.DamageType == Weapon.DamageType);
        if (vulnerability != null)
        {
            damage = damage * vulnerability.Vulnerability;
        }

        foreach(var injury in hitpart.Injures)
        {
            damage = damage * injury.DamageBonus;
        }

        return damage;
    }
}
