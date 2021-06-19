using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pistol", menuName = "Items/Pistol")]
public class Pistol : Gun
{
    private string bulletTag = "PistolBullet";

    public override void Shoot()
    {
        //Store variables
        GameObject player = GameObject.Find("Player");
        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        GameObject firePoint = GameObject.Find("FirePoint");

        //Take a bullet from the pool
        GameObject bulletInstance = ObjectPooler.Instance.SpawnFromPool(bulletTag, firePoint.transform.position, Quaternion.AngleAxis(playerController.aimAngle - 90f, Vector3.forward));

        //Store RB in variable
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();

        //Ignore collision with other bullets and apply physics
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        bulletRb.velocity = new Vector2(playerController.aimDirection.x, playerController.aimDirection.y).normalized * bulletSpeed;
    }

}
