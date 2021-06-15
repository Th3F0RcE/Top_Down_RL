using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Weapon", menuName = "Items/Gun")]
public class Gun : Item
{
    public float bulletSpeed;
    public float fireRate;
    public GameObject bulletPrefab;
}
