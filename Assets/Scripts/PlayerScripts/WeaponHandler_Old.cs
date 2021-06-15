using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler_Old : MonoBehaviour
{
    public GameObject weapon;

    //The Gun Item
    public Gun gun;

    //Objects needed for Shooting and Aiming
    private Transform aim;
    private Transform firePoint;
    private GameObject gunObject;
    private GameObject bulletPrefab;

    private float nextFire;

    //Should Player Shoot?
    private bool shoot;

    //Aiming Variables
    private Vector3 aimDirection;
    private Vector3 mousePos;
    private float aimAngle;

    private void Awake()
    {
        aim = transform.Find("Aim");
        firePoint = transform.Find("FirePoint");
        gunObject = GameObject.Find("Gun");
    }
    private void Start()
    {
        bulletPrefab = gun.bulletPrefab;
        ReplaceWeaponSprite(gun.sprite);
        //Debug.Log("Your Weapon is called \"" + gun.name + "\"");
    }

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
    }

    private void FixedUpdate()
    {
        if(shoot)
        {
            Shoot();
        }
    }

    private void HandleAiming()
    {
        //Mouse-Position Input
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimDirection = (mousePos - transform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aim.eulerAngles = new Vector3(0, 0, aimAngle);

        //Shooting-Input
        if(Input.GetMouseButtonDown(0) && gun.fireRate == 0)
        {
            shoot = true;
        }
        if(Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + (1 / gun.fireRate);
            shoot = true;
        }
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab);
        bulletInstance.transform.position = transform.position;
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        bulletInstance.transform.rotation = Quaternion.AngleAxis(aimAngle - 90f, Vector3.forward);
        bulletRb.velocity = new Vector2(aimDirection.x, aimDirection.y) * gun.bulletSpeed;

        shoot = false;
    }

    //Replaces the current Weapon Sprite with the Sprite of the currently equipped Weapon
    void ReplaceWeaponSprite(Sprite sprite)
    {
        gunObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    //Replaces the current Gun-Item-Object with another one
    public void changeWeapon(Gun changeGun)
    {
        gun = changeGun;
        ReplaceWeaponSprite(changeGun.sprite);
    }
}
