using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Reflect : MonoBehaviour
{

    Rigidbody rb;
    private Vector3 lastVelo;
    private float currentSpeed;
    private Vector3 dir;
    private int reflects = 0;
    //[SerializeField] private int maxReflects;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        lastVelo = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 7) return;

        currentSpeed = lastVelo.magnitude;
        dir = Vector3.Reflect(lastVelo.normalized, collision.contacts[0].normal);

        rb.velocity = dir * Mathf.Max(currentSpeed, 0);

        //reflects++;

    }
}
