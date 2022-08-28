using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button bNewGame;

    public Button bContinueGame;

    private void Start()
    {
        var lastSave = PlayerPrefs.GetString("LastSave");
        
     
        bContinueGame.gameObject.SetActive(!string.IsNullOrEmpty(lastSave));
        
    }

    public void NewGame()
    {
        GameController.instance.InitNewGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ContinueGame()
    {
        GameController.instance.InitContinueGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClearAll()
    {

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        for(var i =1; i<=5; i++)
        {
            var filename = $"Save{i}";

            var filepath = Utils.GetFilePath(filename);

            if(File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}
