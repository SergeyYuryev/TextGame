using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StateText : BaseText
{
    public State State;


    public bool IsShow;
    public bool ShowOnce;

    public override string GetText()
    {
        if (ShowOnce && IsShow)
            return string.Empty;

        IsShow = true;
        return base.GetText();
    }

}



