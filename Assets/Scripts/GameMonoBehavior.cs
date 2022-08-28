using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoBehavior : MonoBehaviour
{
    public SceneController scene;
    // Start is called before the first frame update
    void OnEnable()
    {
        scene = FindObjectOfType<SceneController>();
    }

   
}
