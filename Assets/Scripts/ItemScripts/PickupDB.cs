using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pickup Database", menuName = "Assets/Databases/Pickup Database")]
public class PickupDB : ScriptableObject
{
    public List<GameObject> allPickUpObjects;
}
