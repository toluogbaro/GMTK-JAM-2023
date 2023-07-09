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

    [SerializeField] SCR_Reflective_Surface[] reflectiveWalls;
    [SerializeField] List<GameObject> shootableObjects;
    [SerializeField] float distanceThreshold;
    [SerializeField] Collider _collider;

    private void Awake()
    {
        reflectiveWalls = FindObjectsOfType<SCR_Reflective_Surface>();

        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        var objects = GameObject.FindGameObjectsWithTag("Shootable Object");
        foreach(var obj in objects)
        {
            shootableObjects.Add(obj);
        }
    }

    private void Update()
    {
        DistanceToWallCheck();
        DistanceToShootableObjectsCheck();
    }

    private void LateUpdate()
    {
        lastVelo = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shootable Objects") Destroy(gameObject);
        if (collision.gameObject.layer != 7) return;

        currentSpeed = lastVelo.magnitude;
        dir = Vector3.Reflect(lastVelo.normalized, collision.contacts[0].normal);

        rb.velocity = dir * Mathf.Max(currentSpeed, 0);

        //reflects++;

    }

    void DistanceToWallCheck()
    {
        for(int i = 0; i < reflectiveWalls.Length; i++ )
        {
            float dist = Vector3.Distance(transform.position, reflectiveWalls[i].transform.position);
            if(dist <= distanceThreshold)
            {
                _collider.isTrigger = false;
            }
            else
            {
                _collider.isTrigger = true;
            }
        }
    }

    void DistanceToShootableObjectsCheck()
    {
        for (int i = 0; i < shootableObjects.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, shootableObjects[i].transform.position);
            if (dist <= distanceThreshold)
            {
                _collider.isTrigger = false;
            }
        }
    }
}
