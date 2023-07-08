using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{
    public static SCR_GameManager _instance;

    private void Awake()
    {
        if (_instance != this) Destroy(gameObject);
    }
}
