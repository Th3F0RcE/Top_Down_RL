using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth;
    public float maxMana;

    private float currentHealth;
    private float currentMana;

    private Vector3 mousePos;
    [HideInInspector]
    public Vector3 aimDirection;
    [HideInInspector]
    public float aimAngle;

    private float nextFire;

    public ItemDB allItems;
    public PickupDB allPickupItems;

    public Gun gun;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Weapon").transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gun.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        if(Input.GetKeyDown(KeyCode.G))
        {
            DropWeapon();
        }
    }

    protected void HandleAiming()
    {
        //Mouse-Position Input
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimDirection = (mousePos - transform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, aimAngle);

        Debug.Log(aimAngle);
        if (aimAngle > 90 || aimAngle < -90)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().flipY= true;
        }
        else
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().flipY = false;
        }
        //Shooting-Input
        if(gun != null)
        {
            if (Input.GetMouseButtonDown(0) && gun.fireRate == 0)
            {
                gun.Shoot();
            }
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
            {
                nextFire = Time.time + (1 / gun.fireRate);
                gun.Shoot();
            }
        }
    }

    public void DropWeapon()
    {
        foreach(GameObject pickup in allPickupItems.allPickUpObjects)
        {
            if(pickup.name == gun.name)
            {
                GameObject weaponInstance = Instantiate(pickup, transform.position, Quaternion.identity);
                Physics2D.IgnoreCollision(weaponInstance.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
                //weaponInstance.GetComponent<Rigidbody2D>().AddForce((aimDirection).normalized * 20.0f, ForceMode2D.Impulse);
                weaponInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(aimDirection.x, aimDirection.y).normalized * 10f;
                gun = null;
                //weaponSprite = null;
                GameObject.Find("Weapon").transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = null;
                return;
            }
        }
    }
}
