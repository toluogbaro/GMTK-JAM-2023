using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Pickup : MonoBehaviour
{
    [SerializeField] SCR_Shoot shoot;
    [SerializeField] GunConfiguration _gunType;

    private void Awake()
    {
        shoot = FindObjectOfType<SCR_Shoot>();
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
            gameObject.SetActive(false);
        }
    }
}
