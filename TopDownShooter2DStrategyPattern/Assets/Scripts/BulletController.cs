using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    sbyte damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TomaDano(damage);
            GameObject explosion =
                Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            explosion.transform.rotation = transform.rotation;
            Destroy(gameObject);
        }
    }

    public void configDamage(sbyte damage)
    {
        this.damage = damage;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
