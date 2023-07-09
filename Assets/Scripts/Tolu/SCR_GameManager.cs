using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class SCR_GameManager : MonoBehaviour
{
    public static SCR_GameManager _instance;
    private EventInstance menuMusicInst;

    Scene scene;

    private void Awake()
    {
        _instance = this;
        scene = SceneManager.GetActiveScene();
    }

    void Start()
    {
        if(scene.buildIndex == 0)
        {
            menuMusicInst = RuntimeManager.CreateInstance("event:/MenuMusic");
            menuMusicInst.start();
        }
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

    void OnDestroy()
    {
        StopMenuMusic();
    }

    public void LevelLoader(int level)
    {
        SceneManager.LoadScene(level);
        StopMenuMusic();
    }

    void StopMenuMusic()
    {
        menuMusicInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        menuMusicInst.release();
    }
}
