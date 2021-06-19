using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Shotgun", menuName ="Items/Shotgun")]
public class Shotgun : Gun
{
    public int numberOfBullets;
    [Range(0f, 90f)]
    public float spreadAngle;
}
