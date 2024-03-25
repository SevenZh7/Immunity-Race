using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; // Transform of the point from where bullets will be fired
    public GameObject bulletPrefab; // Prefab of the bullet object
    public float bulletVelocity = 30f;
    public float bulletPrefabLifetime = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward.normalized * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(DestoryBulletAfterTime(bullet, bulletPrefabLifetime));
    }

    private IEnumerator DestoryBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
