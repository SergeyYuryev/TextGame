using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadItemMainMenu : LoadItem
{
    public override void Load()
    {
        var filepath = Utils.GetFilePath(FileName);
        GameController.instance.InitLoadGame(filepath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
