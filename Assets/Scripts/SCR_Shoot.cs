
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Shoot : MonoBehaviour
{
    public GunConfiguration currentGun;

    public GameObject bullet;
    public Transform player;
    public float bpmInterval, counter;
    public float destroyTime;
    public float bulletSpeed;

    private void Update()
    {
        counter += Time.deltaTime;

        if (counter >= bpmInterval)
        {

            foreach (float shot in currentGun.Bullets)
            {
                StartCoroutine(Shoot(shot));
            }
            counter = 0f;
        }
    }

    public IEnumerator Shoot(float shot)
    {
        int numberOfShots = currentGun.Bullets.Length;

        GameObject _bullet = BulletPool.SharedInstance.GetPooledObject();
        if (_bullet != null)
        {
            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = player.rotation;
            _bullet.transform.Rotate(0, shot, 0);
            _bullet.SetActive(true);
        }

        Rigidbody rb = _bullet.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;

        rb.AddForce(_bullet.transform.forward * bulletSpeed);

        _bullet.transform.parent = null;


        yield return new WaitForSeconds(bpmInterval);
        _bullet.SetActive(false);

    }
}