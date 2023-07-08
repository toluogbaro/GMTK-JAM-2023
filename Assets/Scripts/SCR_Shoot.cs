
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

    int maxCycles = 10;
    int currentCycle = 1;
    private void Update()
    {
        counter += Time.deltaTime;

        if (currentCycle < maxCycles && counter >= bpmInterval)
        {
            StartCoroutine(Shoot());
            counter = 0f;
            currentCycle++;
        }
    }

    public IEnumerator Shoot()
    {
        int numberOfShots = currentGun.Bullets.Length;

        foreach (float shot in currentGun.Bullets)
        {

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


        yield return null;


    }
}


//private IEnumerator ShootSpread()
//{
//    IsShooting = true;

//    float angleIncrement = degree / (bulletAmount - 1);
//    Quaternion startRotation = firePoint.rotation;

//    for (int i = 0; i < bulletAmount; i++)
//    {
//        Quaternion spreadRotation = Quaternion.AngleAxis(-degree / 2 + (i * angleIncrement), Vector3.forward);
//        Quaternion bulletRotation = startRotation * spreadRotation;

//        GameObject projectileObject = Instantiate(projectilePrefab, firePoint.position, bulletRotation);

//        if (projectileObject.TryGetComponent(out ProjectileMovement projectile))
//        {
//            Vector3 initialDirection = (Player.position - firePoint.position).normalized;
//            Vector3 spreadDirection = spreadRotation * initialDirection;
//            projectile.SetVelocity(spreadDirection, bulletSpeed);
//            projectile.SetRange(BulletRange);
//            projectile.SetDamage(damage);
//            projectile.SetEnemyBullet();
//            projectile.SetBulletScale(bulletScale);
//        }
//    }

//    yield return new WaitForSeconds(RestTime);

//    IsShooting = false;
//}