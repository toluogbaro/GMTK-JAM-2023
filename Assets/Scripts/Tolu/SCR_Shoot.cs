
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Shoot : MonoBehaviour
{
    public GunConfiguration currentGun;
    public Transform player;
    public float bpmInterval, counter;
    public float destroyTime;
    public float bulletSpeed;

    private List<GameObject> magazine;

    private void Start()
    {
        magazine = new List<GameObject>();
    }

    private void OnEnable()
    {
        SCR_BeatSystem.OnMarkerUpdate += HandleMarkerUpdate;
        SCR_BeatSystem.OnBeatUpdate += HandleBeatUpdate;
    }
    private void OnDisable()
    {
        SCR_BeatSystem.OnMarkerUpdate -= HandleMarkerUpdate;
        SCR_BeatSystem.OnBeatUpdate -= HandleBeatUpdate;
    }

    private void HandleMarkerUpdate(string updatedString)
    {
        if (magazine.Count != currentGun.Bullets.Length)
        {
            for (int i = 0; i < currentGun.Bullets.Length; i++)
            {
                magazine.Add(BulletPool.SharedInstance.GetPooledObject());

            }
        }

        //foreach (GameObject go in magazine)
        //{
        //    go.SetActive(false);
        //}

        for (int j = 0; j < magazine.Count; j++)
        {
            magazine[j].SetActive(false);
            Debug.Log(j +"st angle is " + currentGun.Bullets[j]);
            StartCoroutine(Shoot(magazine[j], currentGun.Bullets[j], j));
        }
    }

    private void HandleBeatUpdate(int updatedString)
    {
    }

    private void LoadBullets(int magazineCap)
    {
        for (int i = 0; i < currentGun.Bullets.Length; i++)
        {
            magazine[i] = BulletPool.SharedInstance.GetPooledObject();
        }
    }

    public IEnumerator Shoot(GameObject _bullet, float rotation, int shot)
    {
        if (_bullet != null)
        {
            Debug.Log("Current rotation of array obj is " + magazine[shot].transform.rotation + " and of passed obj is " + _bullet.transform.rotation);
            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = player.rotation;
            _bullet.transform.Rotate(0, rotation, 0);
            Debug.Log("New rotation of array obj is " + magazine[shot].transform.rotation + " and of passed obj is " + _bullet.transform.rotation);
            _bullet.SetActive(true);
        }

        Rigidbody rb = _bullet.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;

        rb.AddForce(_bullet.transform.forward * bulletSpeed);

        _bullet.transform.parent = null;


        yield return null;

    }
}