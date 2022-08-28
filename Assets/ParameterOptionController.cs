using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParameterOptionController : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public float MaxCount;
    public float LeftCount;
    public ParameterOption[] Options;
    public Button bContinue;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var option in Options)
        {
            option.Slider.minValue = 0f;
            option.Slider.maxValue = 9f;
            option.controller = this;
        }

        LeftCount = MaxCount;

        CountText.text = LeftCount.ToString();

        CheckButton();
    }

    public void CheckButton()
    {
        if (bContinue != null)
            bContinue.enabled = LeftCount == 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
