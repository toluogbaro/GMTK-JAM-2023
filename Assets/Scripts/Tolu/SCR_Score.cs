using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCR_Score : MonoBehaviour
{
    public SCR_ScoreHolder scoreHolder;

    public TextMeshProUGUI score;

    public int ReturnScore()
    {
        switch (scoreHolder.scoreType)
        {
            case ScoreType.CIVILIANSKILLED:
                return SCR_ScoreScreen.civiliansKilled;

            case ScoreType.OBJECTSDESTORYED:
                return SCR_ScoreScreen.objectsDestroyed;

            case ScoreType.DISTANCECOVERED:
                return SCR_ScoreScreen.distanceCovered;

            default:
                return 0;
        }
    }
}
