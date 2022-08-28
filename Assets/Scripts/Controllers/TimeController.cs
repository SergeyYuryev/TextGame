using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public Parameter Hour;
    public Parameter Minute;
    public Parameter Day;
    public Parameter DayOfWeek;
    public Parameter PartOfDay;
    public string[] DaysOfWeek = new string[]
    {
    "Понедельник", "Вторник", "Среда", "Четверг", "Пятница","Суботта","Воскресенье" 
    };

    public string[] PartsOfDay = new string[]
   {
    "Ночь", "Утро", "День", "Вечер"
   };

    private void Start()
    {
        UpdateTime();
    }
    public void addTime(int minute)
    {
        this.Minute.intValue = this.Minute.intValue + minute;
        UpdateTime();
    }

    public void UpdateTime()
    {
        if (Minute.intValue >= 60)
        {
            Hour.intValue++;
            Minute.intValue = Minute.intValue - 60;
        }
        if (Hour.intValue >= 24)
        {
            Day.intValue++;
            Hour.intValue = Hour.intValue - 24;
        }
        if (Hour.intValue >= 0 && Hour.intValue < 6)
            PartOfDay.Value = PartsOfDay[0];
        if (Hour.intValue >= 6 && Hour.intValue < 12)
            PartOfDay.Value = PartsOfDay[1];
        if (Hour.intValue >= 12 && Hour.intValue < 18)
            PartOfDay.Value = PartsOfDay[2];
        if (Hour.intValue >= 18 && Hour.intValue <= 24)
            PartOfDay.Value = PartsOfDay[3];

        int index = Day.intValue % 7;
        DayOfWeek.Value = DaysOfWeek[index];
    }

    public override string ToString()
    {
        var minutes =  Minute.Value;

        if (minutes.Length == 1)
            minutes = "0" + minutes;

        return $"{DayOfWeek.Value} {PartOfDay.Value} {Hour.Value}:{minutes}";

    }
}
