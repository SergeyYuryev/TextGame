using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadItem : GameMonoBehavior
{
    
    public string FileName;
    public Button Slot;
    private void Start()
    {
        Init();
    }

    private string GetKey()
    {
        return $"saveitem_{FileName}";
    }

    internal void Init()
    {
        var text = Slot.GetComponentInChildren<TextMeshProUGUI>();
        text.text = FileName;

        var filepath = Utils.GetFilePath(FileName);

        if(File.Exists(filepath))
        {
            var jsondata = PlayerPrefs.GetString(GetKey());
            var saveData = JsonUtility.FromJson<SaveData>(jsondata);


            var saved = DateTime.Parse(saveData.saved);
            text.text = $"{saveData.name} - сохранено {saved:g}";
        }
        else
        {
            text.text = "Пустая ячейка";
            Slot.enabled = false;
        }


    }
    public virtual void Load()
    {
        var filepath = Utils.GetFilePath(FileName);
        scene.LoadGame(filepath);
        scene.Controller.ShowMainPanel();

    }
}
