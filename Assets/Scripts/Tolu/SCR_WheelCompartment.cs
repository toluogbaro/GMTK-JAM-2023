using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_WheelCompartment : MonoBehaviour
{
   

    public GunConfiguration gunConfiguration;
    public Image image;
    public List<Sprite> spriteList;
    public SCR_Shoot shootScript;

    private void Awake()
    {
        if (!gunConfiguration) return;

        InitializeImage();
    }

    void InitializeImage()
    {
        switch (gunConfiguration.gunType)
        {
            case GunType.PISTOL:
                image.sprite = spriteList[0];
                break;

            case GunType.SHOTGUN:
                image.sprite = spriteList[1];
                break;

            case GunType.AKIMBO:
                image.sprite = spriteList[2];
                break;

        }

    }
}
