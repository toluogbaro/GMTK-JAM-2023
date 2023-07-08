
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

    SCR_AudioManager audioManager;

    private List<GameObject> magazine;

    private void Start()
    {
        magazine = new List<GameObject>();
        audioManager = FindObjectOfType<SCR_AudioManager>();
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
        try
        {
            if (magazine.Count != currentGun.Bullets.Length)
            {
                magazine = new List<GameObject>();
                for (int i = 0; i < currentGun.Bullets.Length; i++)
                {
                    GameObject _bullet = BulletPool.SharedInstance.GetPooledObject();
                    if (_bullet != null)
                    {
                        //_bullet.transform.position = transform.position;
                        //_bullet.transform.rotation = player.rotation;
                        //_bullet.transform.Rotate(0, currentGun.Bullets[i], 0);
                        _bullet.SetActive(true);
                    }
                    magazine.Add(_bullet);


                }
            }

            for (int j = 0; j < magazine.Count; j++)
            {

                magazine[j].SetActive(false);
                StartCoroutine(Shoot(magazine[j], currentGun.Bullets[j], j));
                audioManager.musicInstance.setParameterByNameWithLabel("Mode", currentGun.audioParam);
            }
        } catch (System.Exception ex)
        {
            //print(ex);
            print("No weapon. Waiting...");
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
        if (!_bullet.activeSelf)
        {
            _bullet.transform.position = transform.position;
            _bullet.transform.rotation = player.rotation;
            _bullet.transform.Rotate(0, rotation, 0);
            _bullet.SetActive(true);
        }

        Rigidbody rb = _bullet.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;

        rb.AddForce(_bullet.transform.forward * bulletSpeed);

        _bullet.transform.parent = null;

        yield return null;

    }
}