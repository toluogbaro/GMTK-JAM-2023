using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ButtonAudio : MonoBehaviour
{
    public void Click()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI Select");
    }
    public void Hover()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI Change Selection");
    }
}
