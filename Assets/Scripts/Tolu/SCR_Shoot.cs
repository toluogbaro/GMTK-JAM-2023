using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float bpmInterval, counter;
    public float destroyTime;
    public float bulletSpeed;

    

    private void Update()
    {
        counter += Time.deltaTime;

        if (counter >= bpmInterval)
        {
            StartCoroutine(Shoot());
            counter = 0f;
        }
    }

    public IEnumerator Shoot()
    {
        GameObject _bullet = Instantiate(bullet, transform);

        _bullet.transform.position = transform.position;

        Rigidbody rb = _bullet.GetComponent<Rigidbody>();

        rb.AddForce(_bullet.transform.forward * bulletSpeed);

        yield return new WaitForSeconds(bpmInterval);

        Destroy(_bullet);

        yield return null;


    }
}
