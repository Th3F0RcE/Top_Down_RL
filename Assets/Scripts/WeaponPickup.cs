using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Gun gun;
    public string weaponName;

    //Time to stop sliding on the ground
    private float stopVelocityTime;

    private void Start()
    {
        stopVelocityTime = Time.time + 0.2f;
    }
    private void Update()
    {
        //Stop Movement of Weapon and re-enable collider trigger
        if(Time.time > stopVelocityTime)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;

            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>(), false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pickup the item
        if(collision.tag.Equals("Player"))
        {
            if(collision.GetComponent<PlayerController>().gun != null)
            {
                collision.GetComponent<PlayerController>().DropWeapon();
            }

            collision.GetComponent<PlayerController>().gun = gun;
            collision.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = gun.sprite;
            Destroy(gameObject);
        }
    }
}
