using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParameterOption : MonoBehaviour
{
    public string OptionId;
    public ParameterOptionController controller;

    public int Value;
    public Slider Slider;
    public TextMeshProUGUI ValueText;
    public TextMeshProUGUI RankText;
    // Start is called before the first frame update
    void Start()
    {
        Slider.onValueChanged.AddListener(ValueChanged);
        updateRank();
    }

 

    void ValueChanged(float value)
    {
        ValueText.text = value.ToString();

        var usedaccount = 0f;

        foreach (var optopn in controller.Options)
        {
            usedaccount += optopn.Slider.value;
        }
        controller.LeftCount = controller.MaxCount - usedaccount;

        if (controller.LeftCount < 0)
        {
            Slider.value = Slider.value - 1f;
        }

        
        controller.CountText.text = controller.LeftCount.ToString();
        

        PlayerPrefs.SetString(OptionId, Slider.value.ToString());
        PlayerPrefs.Save();
        updateRank();
        controller.CheckButton();
    }

    void updateRank()
    {
        if (Slider.value < 4)
        {
            RankText.text = "рядовой";
        }
        else if (Slider.value < 7)
        {
            RankText.text = "профи";
        }
        else
        {
            RankText.text = "эксперт";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
