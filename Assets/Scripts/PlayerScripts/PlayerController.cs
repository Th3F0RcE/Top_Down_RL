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
