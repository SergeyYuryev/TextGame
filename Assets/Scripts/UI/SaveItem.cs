using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveItem : GameMonoBehavior
{
    public string FileName;
    public Button Slot;

    private string GetKey()
    {
        return $"saveitem_{FileName}";
    }

    private void Start()
    {
        Init();
    }
    internal void Init()
    {
        var text = Slot.GetComponentInChildren<TextMeshProUGUI>();
        text.text = FileName;

        var filepath = Utils.GetFilePath(FileName);

        if (File.Exists(filepath))
        {
            var jsondata = PlayerPrefs.GetString(GetKey());
            var saveData = JsonUtility.FromJson<SaveData>(jsondata);


            var saved = DateTime.Parse(saveData.saved);
            text.text = $"{saveData.name} - сохранено {saved:g}";
        }
        else
        {
            text.text = "Свободная ячейка";
          
        }


    }

    public void Save()
    {
        scene.SaveGame(FileName);

        var savedata = new SaveData
        {
            name = scene.CurretWorkflow.State.Title,
            saved = System.DateTime.Now.ToString()

        };
        var datastring = JsonUtility.ToJson(savedata);


        PlayerPrefs.SetString(GetKey(), datastring);
        PlayerPrefs.Save();

        Init();

    }
}
