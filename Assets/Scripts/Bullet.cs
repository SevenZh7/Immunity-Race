using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    private void OnCollisionEnter(Collision objectWeHit)
    {
        if (objectWeHit.gameObject.CompareTag("Enemy"))
        {
            objectWeHit.gameObject.GetComponent<Zombie>().TakeDamage(bulletDamage);
        }
    }
}
