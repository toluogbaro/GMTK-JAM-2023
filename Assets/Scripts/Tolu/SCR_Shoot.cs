
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
            StartCoroutine(Shoot());
            counter = 0f;
        }
    }

    public IEnumerator Shoot()
    {
        int numberOfShots = currentGun.Bullets.Length;

        foreach (float shot in currentGun.Bullets)
        {
            GameObject _bullet = Instantiate(bullet, transform);

            _bullet.transform.position = transform.position;

            _bullet.transform.rotation = player.rotation;
            bullet.transform.Rotate(0, shot, 0);

            Debug.Log(shot + "'s transform forward is " + bullet.transform.forward);

            Rigidbody rb = _bullet.GetComponent<Rigidbody>();

            rb.AddForce(_bullet.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bpmInterval);

            Destroy(_bullet);
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