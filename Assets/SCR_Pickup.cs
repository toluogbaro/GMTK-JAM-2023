using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Pickup : MonoBehaviour
{
    [SerializeField] SCR_Shoot shoot;
    [SerializeField] GunConfiguration _gunType;

    private void Awake()
    {
      
    }

    private void Start()
    {
        shoot = SCR_Shoot.SharedInstance;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        shoot.currentGun.gunType = _gunType;
    //        gameObject.SetActive(false);
    //    }


    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shoot.currentGun = _gunType;
            //play sound for weapon pickup
            switch(_gunType.gunType)
            {
                case GunType.AKIMBO:
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/BurstPickup");
                    return;
                }

                case GunType.PISTOL:
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/PistolPickup");
                    return;
                }

                case GunType.SHOTGUN:
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/ShotgunPickup");
                    return;
                }
                default:
                {
                    return;
                }

            }
            gameObject.SetActive(false);
        }
    }
}
