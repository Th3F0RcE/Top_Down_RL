using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth;
    public float maxMana;

    private float currentHealth;
    private float currentMana;

    private bool canPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Item"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Item"))
        {
            canPickUp = true;
        }

        if(Input.GetKeyDown(KeyCode.F) && canPickUp)
        {
        }
    }
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canPickUp)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        //gameObject.GetComponent<WeaponHandler>().changeWeapon();
    }
}
