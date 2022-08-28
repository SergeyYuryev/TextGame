using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Root;

    public ParameterContainer Parameters;
    public Workflow CurretWorkflow;
    public TimeController TimeController;

    public UIController Controller;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene arg0, LoadSceneMode arg1)
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex > 0)
        {
            var filepath = PlayerPrefs.GetString("LoadFile");
            if (string.IsNullOrEmpty(filepath))
            {
                if (CurretWorkflow != null)
                    CurretWorkflow.SetState(CurretWorkflow.State);

                foreach(var param in Parameters.Parameters)
                {
                    param.Value = PlayerPrefs.GetString(param.Id);
                }
            }
            else
            {
                LoadGame(filepath);
            }
        }
    }


 

    //public void LoadGame()
    //{
    //    var filepath = Application.persistentDataPath + "/" + FileName;
    //    LoadGame(filepath);

    //}
    public void LoadGame(string filepath)
    {

        var data = File.ReadAllText(filepath);
        var gamedata = JsonUtility.FromJson<GameData>(data);
      CurretWorkflow = GetObject(gamedata.currentWorkflow).GetComponent<Workflow>();


        foreach (var workflow in gamedata.workflows)
        {
            var gameobject = GetObject(workflow.name);

            var gworkflow = gameobject.GetComponent<Workflow>();

            var stategameobject = GetObject(workflow.statename);
            var gstate = stategameobject.GetComponent<State>();
            gworkflow.State = gstate;

        }
        foreach (var parameter in gamedata.parameters)
        {
            var gameobject = GetObject(parameter.path);

            var gparameter = gameobject.GetComponent<Parameter>();

            gparameter.Value = parameter.value;
        }

        Controller.InitState(CurretWorkflow.State);
    }

    public void SaveGame(string filename)
    {


        var data = new GameData { };

        var list = new List<WorkflowData>();

        var workflows = Root.GetComponentsInChildren<Workflow>();

        data.currentWorkflow = GetPath((CurretWorkflow as MonoBehaviour).gameObject);


        foreach (var workflow in workflows)
        {


            var wd = new WorkflowData();
            wd.name = GetPath((workflow as MonoBehaviour).gameObject);


            var state = workflow.State;

            if (state != null)
            {
                wd.statename = GetPath((workflow.State as MonoBehaviour).gameObject);
            }
            list.Add(wd);
        }

        var parameters = Root.GetComponentsInChildren<Parameter>();

        var listofParameters = new List<ParameterData>();
        foreach (var parameter in parameters)
        {
            var pd = new ParameterData
            {

                path = GetPath((parameter as MonoBehaviour).gameObject),
                value = parameter.Value
            };

            listofParameters.Add(pd);
        }


        data.workflows = list.ToArray();
        data.parameters = listofParameters.ToArray();

        var datastring = JsonUtility.ToJson(data);

        var destination = Utils.GetFilePath(filename);

        File.WriteAllText(destination, datastring);



        PlayerPrefs.SetString("LastSave", destination);
        PlayerPrefs.Save();

    }



    protected string GetPath(GameObject mb)
    {
        var path = new StringBuilder();

        path.Append(mb.name);

        var current = mb;
        while (current.transform.parent != null)
        {
            path.Insert(0, $"{current.transform.parent.name}/");

            current = current.transform.parent.gameObject;
        }



        return path.ToString();
    }
    protected GameObject GetObject(string path)
    {
        var items = path.Split('/');
        var curentitem = Root;
        foreach (var item in items)
        {
            if (item == Root.name)
                continue;
            var childitem = curentitem.transform.Find(item).gameObject;

            curentitem = childitem;
        }


        return curentitem;
    }

}
