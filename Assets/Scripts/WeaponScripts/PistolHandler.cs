using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolHandler : WeaponHandler
{
    void Awake()
    {
        base.OnAwake();
    }

    // Start is called before the first frame update
    void Start()
    {
        base.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        base.HandleAiming();
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
        GameObject bulletInstance = Instantiate(bulletPrefab);
        bulletInstance.transform.position = transform.position;
        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());

        bulletInstance.transform.rotation = Quaternion.AngleAxis(aimAngle - 90f, Vector3.forward);
        bulletRb.velocity = new Vector2(aimDirection.x, aimDirection.y) * gun.bulletSpeed;

        shoot = false;
    }
}
