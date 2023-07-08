using UnityEngine;

class SCR_AudioManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private SCR_BeatSystem bS;

    void Start()
    {
        bS = GetComponent<SCR_BeatSystem>();     
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(PlaybackState(instance) != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                instance = FMODUnity.RuntimeManager.CreateInstance("event:/music");
                instance.start();
                bS.AssignBeatEvent(instance);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bS.StopAndClear(instance);
        }

        Debug.Log(SCR_BeatSystem.marker);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            instance.setParameterByName("Mode", 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            instance.setParameterByName("Mode", 1);
        }

    }

    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance) 
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }
}

