using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponHandler : MonoBehaviour
{
    public Gun gun;

    //Objects needed for Shooting and Aiming
    //private Transform aim;
    private Transform firePoint;
    //private GameObject gunObject;
    protected GameObject bulletPrefab;

    private float nextFire;

    //Should Player Shoot?
    protected bool shoot;

    //Aiming Variables
    protected Vector3 aimDirection;
    private Vector3 mousePos;
    protected float aimAngle;

    protected virtual void OnAwake()
    {
        firePoint = transform.Find("FirePoint");
        gameObject.GetComponent<SpriteRenderer>().sprite = gun.sprite;
    }

    protected virtual void OnStart()
    {
        bulletPrefab = gun.bulletPrefab;
    }

    protected virtual void HandleAiming()
    {
        //Mouse-Position Input
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimDirection = (mousePos - transform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, aimAngle);

        //Debug.Log(aimAngle);
        
        if(aimAngle > 90 || aimAngle < -90)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }
        
        //Shooting-Input
        if (Input.GetMouseButtonDown(0) && gun.fireRate == 0)
        {
            shoot = true;
        }
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + (1 / gun.fireRate);
            shoot = true;
        }
    }

    protected abstract void Shoot();
}
