using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void LoadScene()
    {
        
    }

    void SwitchToSettings()
    {

    }

    void QuitGame()
    {
        Application.Quit();
    }
}
