using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage;
    private string bulletTag = "PistolBullet";
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().setCurrentHealth(collision.gameObject.GetComponent<Enemy>().getCurrentHealth() - damage);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.35f);
        ObjectPooler.Instance.returnObject(bulletTag, gameObject);
    }
}
