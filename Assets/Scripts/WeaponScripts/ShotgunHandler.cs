using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunHandler : WeaponHandler
{
    private Shotgun shotgun;
    private string bulletTag = "PistolBullet";

    void Awake()
    {
        base.OnAwake();
    }
    // Start is called before the first frame update
    void Start()
    {
        base.OnStart();
        shotgun = (Shotgun)gun;
    }

    // Update is called once per frame
    void Update()
    {
        base.HandleAiming();
        Debug.Log(shotgun.numberOfBullets);
    }

    private void FixedUpdate()
    {
        if(shoot)
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
        //TODO: Add ROWS to Shotgun Shots
        
        GameObject[] bullets = new GameObject[shotgun.numberOfBullets];

        Vector3 rotation;

        Vector3 playerRotation = transform.rotation.eulerAngles;

        for (int i = 0; i < shotgun.numberOfBullets; ++i)
        {
            if (i == 0)
            {
                rotation = playerRotation - new Vector3(0, 0, -90f);
                //bullets[i] = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, -90f)));
            }
            else if (i % 2 == 0 && i != 0)
            {
                rotation = playerRotation - new Vector3(0, 0, Random.Range(0f,shotgun.spreadAngle) * (i - 1) - 90f);
                //bullets[i] = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, shotgun.spreadAngle * (i-1) - 90f)));
            }
            else
            {
                rotation = playerRotation - new Vector3(0, 0, -Random.Range(0f, shotgun.spreadAngle) * i - 90f);
                //bullets[i] = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, -shotgun.spreadAngle * i - 90f)));
            }

            bullets[i] = ObjectPooler.Instance.SpawnFromPool(bulletTag, transform.position, Quaternion.Euler(rotation));
            //bullets[i] = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(rotation));
            Physics2D.IgnoreCollision(bullets[i].GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
            /*
            Debug.Log("BEFORE SHOT: " + " " + "Bullet number " + i+1 + " " + bullets[i].GetComponent<Rigidbody2D>().velocity);
            bullets[i].GetComponent<Rigidbody2D>().AddForce(-bullets[i].transform.up * shotgun.bulletSpeed, ForceMode2D.Impulse);
            Debug.Log("AFTER SHOT: " + " " + "Bullet number " + i + 1 + " " + bullets[i].GetComponent<Rigidbody2D>().velocity);
            */
            bullets[i].GetComponent<Rigidbody2D>().velocity = -bullets[i].transform.up * shotgun.bulletSpeed;
            Debug.Log("AFTER SHOT: " + " " + "Bullet number " + i + 1 + " " + bullets[i].GetComponent<Rigidbody2D>().velocity);
        }

        shoot = false;
    }
}
