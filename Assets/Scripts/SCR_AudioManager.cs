using UnityEngine;

class SCR_AudioManager : MonoBehaviour
{
    public FMOD.Studio.EventInstance musicInstance;
    private SCR_BeatSystem bS;

    void Start()
    {
        bS = GetComponent<SCR_BeatSystem>();  

        if(PlaybackState(musicInstance) != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/music");
                musicInstance.start();
                bS.AssignBeatEvent(musicInstance);
            } 
    }

    void OnDestroy()
    {
        bS.StopAndClear(musicInstance);
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         if(PlaybackState(musicInstance) != FMOD.Studio.PLAYBACK_STATE.PLAYING)
    //         {
    //             musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/music");
    //             musicInstance.start();
    //             bS.AssignBeatEvent(musicInstance);
    //         }
    //     }

    //     if (Input.GetKeyDown(KeyCode.LeftControl))
    //     {
    //         bS.StopAndClear(musicInstance);
    //     }

    //     //Debug.Log(SCR_BeatSystem.marker);

    //     // if (Input.GetKeyDown(KeyCode.Alpha1))
    //     // {
    //     //     instance.setParameterByName("Mode", 0);
    //     // }

    //     // if (Input.GetKeyDown(KeyCode.Alpha2))
    //     // {
    //     //     instance.setParameterByName("Mode", 1);
    //     // }

    // }

    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance) 
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }
}

