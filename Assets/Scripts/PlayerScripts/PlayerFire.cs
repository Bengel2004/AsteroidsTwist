﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Weapon chosenWeapon;
    public ObjectPooler bulletPool;

    private float timestamp = 0.0f;
    [SerializeField]
    private Transform bulletSpawnPosition;

    private void Start()
    {
        timestamp = Time.time + 0.0f;   
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time > timestamp)
            {
                Fire(GameManager.playerLevel);
            }
        }
    }

    // Fires weapon
    private void Fire(int _level)
    { 
        timestamp = Time.time + (chosenWeapon.rateOfFire / 60); // 60 seconds
        GameObject _tempBullet = bulletPool.GetNext(_level, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
    }
}
