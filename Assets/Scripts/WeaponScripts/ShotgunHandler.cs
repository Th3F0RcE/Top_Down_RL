using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunHandler : WeaponHandler
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

    protected override void Shoot()
    {
        
    }
}
