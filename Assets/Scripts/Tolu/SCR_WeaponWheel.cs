using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_WeaponWheel : MonoBehaviour
{
    [SerializeField] List<Vector3> wheelPositions;
    [SerializeField] List<GameObject> wheelCompartments;
    [SerializeField] GameObject currentWeapon;

    private SCR_Shoot shootScript;
    private void Awake()
    {
        shootScript = SCR_Shoot.SharedInstance;
    }

    private void Update()
    {
        MoveCycle();

    }

    //void MoveUIPositions()
    //{
    //    if (currentWeapon.GetComponent<SCR_WheelCompartment>().gunConfiguration.gunType == shootScript.currentGun.gunType) return;

    //    wheelCompartments[0].LeanMoveLocal(wheelPositions[0], 0.4f).setEaseInBack();
    //    wheelCompartments[0].LeanScale(new Vector3(1.2f, 1.2f, 1f), 0.4f);

    //    wheelCompartments[1].LeanMoveLocal(wheelPositions[1], 0.4f).setEaseInBack();
    //    wheelCompartments[1].LeanScale(new Vector3(1f, 1f, 1f), 0.4f);

    //    wheelCompartments[2].LeanMoveLocal(wheelPositions[2], 0.4f).setEaseInBack();
    //    wheelCompartments[2].LeanScale(new Vector3(1, 1, 1f), 0.4f);
    //}

    IEnumerator MoveUIPositions()
    {
        wheelCompartments[0].LeanMoveLocal(wheelPositions[0], 0.4f).setEaseInBack();
        wheelCompartments[0].LeanScale(new Vector3(1.2f, 1.2f, 1f), 0.4f);

        yield return new WaitForSecondsRealtime(0.1f);

        wheelCompartments[1].LeanMoveLocal(wheelPositions[1], 0.4f).setEaseInBack();
        wheelCompartments[1].LeanScale(new Vector3(1f, 1f, 1f), 0.4f);

        yield return new WaitForSecondsRealtime(0.1f);

        wheelCompartments[2].LeanMoveLocal(wheelPositions[2], 0.4f).setEaseInBack();
        wheelCompartments[2].LeanScale(new Vector3(1, 1, 1f), 0.4f);

        yield return null;
    }

    void MoveCycle()
    {
        if (!shootScript.currentGun || currentWeapon.GetComponent<SCR_WheelCompartment>().gunConfiguration.gunType == shootScript.currentGun.gunType) return;

        switch (shootScript.currentGun.gunType)
        {
            case GunType.PISTOL:
                foreach(GameObject obj in wheelCompartments)
                {
                    if(obj.GetComponent<SCR_WheelCompartment>().gunConfiguration.gunType == GunType.PISTOL)
                    {
                        currentWeapon = obj;
                    }
                }
                if (wheelCompartments[0] != currentWeapon)
                {
                  int indexToSwap = wheelCompartments.IndexOf(currentWeapon);
                    wheelCompartments[3] = wheelCompartments[0];
                    wheelCompartments[0] = wheelCompartments[indexToSwap];
                    wheelCompartments[indexToSwap] = wheelCompartments[3];

                }
                StartCoroutine(MoveUIPositions());
                break;

            case GunType.AKIMBO:
                foreach (GameObject obj in wheelCompartments)
                {
                    if (obj.GetComponent<SCR_WheelCompartment>().gunConfiguration.gunType == GunType.AKIMBO)
                    {
                        currentWeapon = obj;
                    }
                }
                if (wheelCompartments[0] != currentWeapon)
                {
                    int indexToSwap = wheelCompartments.IndexOf(currentWeapon);
                    wheelCompartments[3] = wheelCompartments[0];
                    wheelCompartments[0] = wheelCompartments[indexToSwap];
                    wheelCompartments[indexToSwap] = wheelCompartments[3];

                }
                StartCoroutine(MoveUIPositions());
                break;

            case GunType.SHOTGUN:
                foreach (GameObject obj in wheelCompartments)
                {
                    if (obj.GetComponent<SCR_WheelCompartment>().gunConfiguration.gunType == GunType.SHOTGUN)
                    {
                        currentWeapon = obj;
                    }
                }
                if (wheelCompartments[0] != currentWeapon)
                {
                    int indexToSwap = wheelCompartments.IndexOf(currentWeapon);
                    wheelCompartments[3] = wheelCompartments[0];
                    wheelCompartments[0] = wheelCompartments[indexToSwap];
                    wheelCompartments[indexToSwap] = wheelCompartments[3];

                }
                StartCoroutine(MoveUIPositions());
                break;

        }
    }




}
