using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_GameManager : MonoBehaviour
{
    public static SCR_GameManager _instance;

    Scene scene;

    private void Awake()
    {
        _instance = this;
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        
        if(scene.buildIndex == 0)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }

 

    public void LevelLoader(int level)
    {
        SceneManager.LoadScene(level);
    }
}
