using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{
    public static int globalBPM;
    public static bool isActionReady;


    public static void CalculateInterval()
    {
        int bpmStep = globalBPM / 60;
    }
}
