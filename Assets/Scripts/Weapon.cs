using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damagePerShot = 20; // Amount of damage dealt per shot
    public float fireRate = 0.5f; // Rate of fire (shots per second)
    public Transform shootingPoint; // Shooting point GameObject
    public GameObject bulletPrefab; // Reference to the bullet prefab


    private float nextFireTime; // Time of the next allowed shot

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Update next allowed shot time
        }
    }



    void Shoot()
    {
        RaycastHit hit;
         Debug.Log("Shoot method called.");
        if (Physics.Raycast(shootingPoint.position, shootingPoint.forward, out hit))
        {
            // Check if the object hit by the raycast has an Enemy component
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damagePerShot);
            }
        }
    }

}
