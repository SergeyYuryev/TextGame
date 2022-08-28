using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController instance = null; // Экземпляр объекта

  

  

    public float FontSize = 14f;

  
    public string FileName;
   
 
    // Start is called before the first frame update
    void OnEnable()
    {

        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        // Теперь нам нужно указать, чтобы объект не уничтожался
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);

        // И запускаем собственно инициализатор
        InitializeManager();

      
      
    }


    // Метод инициализации менеджера
    private void InitializeManager()
    {
      

    }
  
    // Метод для сохранения текущих настроек
    public  void saveSettings()
    {
        PlayerPrefs.SetString("fontSize", FontSize.ToString());  
     
        PlayerPrefs.Save(); // Сохраняем настройки
    }

    internal void InitNewGame()
    {
        PlayerPrefs.SetString("LoadFile", string.Empty);
        PlayerPrefs.Save();
    }

    internal void InitContinueGame()
    {
        var getlastsave = PlayerPrefs.GetString("LastSave");
        PlayerPrefs.SetString("LoadFile", getlastsave);
        PlayerPrefs.Save();
    }

    internal void InitLoadGame(string filepath)
    {
        
        PlayerPrefs.SetString("LoadFile", filepath);
        PlayerPrefs.Save();
    }


}
