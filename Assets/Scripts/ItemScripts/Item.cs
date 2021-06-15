using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string id;
    public new string name;
    [TextArea]
    public string description;
    [TextArea]
    public string flavorText;
    public Sprite sprite;
    public float damage;
    public bool pickupAllowed;
}
