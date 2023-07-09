using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Reflective_Surface : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
        }
    }
}
