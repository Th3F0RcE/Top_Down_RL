using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Shotgun", menuName ="Items/Shotgun")]
public class Shotgun : Gun
{
    public int numberOfBullets;
    [Range(0, 90)]
    public int spreadAngle;
    private string bulletTag = "PistolBullet";

    public override void Shoot()
    {
        //TODO: Add ROWS to Shotgun Shots
        GameObject[] bullets = new GameObject[numberOfBullets];
        Collider2D playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();

        Vector3 weaponPosition = GameObject.Find("Weapon").transform.position;

        Vector3 weaponRotation = GameObject.Find("Weapon").transform.rotation.eulerAngles;
        Vector3 rotation;

        for (int i = 0; i < numberOfBullets; ++i)
        {
            if (i == 0)
            {
                rotation = weaponRotation - new Vector3(0, 0, -90f);
            }
            else if (i % 2 == 0 && i != 0)
            {
                rotation = weaponRotation - new Vector3(0, 0, spreadAngle * (i - 1) - 90f);
            }
            else
            {
                rotation = weaponRotation - new Vector3(0, 0, -spreadAngle * i - 90f);
            }
            bullets[i] = ObjectPooler.Instance.SpawnFromPool(bulletTag, weaponPosition, Quaternion.Euler(rotation));

            Physics2D.IgnoreCollision(bullets[i].GetComponent<Collider2D>(), playerCollider);
            //bullets[i].GetComponent<Rigidbody2D>().AddForce(-bullets[i].transform.up * bulletSpeed, ForceMode2D.Impulse);
            bullets[i].GetComponent<Rigidbody2D>().velocity = -bullets[i].transform.up * bulletSpeed;
        }
    }
}

