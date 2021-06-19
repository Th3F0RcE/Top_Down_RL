using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Projectile"))
        {
            currentHealth -= 10f;
        }
    }
    */

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public void setCurrentHealth(float newHealth)
    {
        currentHealth = newHealth;
    }
}
