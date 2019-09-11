using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Weapon chosenWeapon;
    private float timestamp = 0.0f;
    [SerializeField]
    private Transform bulletSpawnPosition;
    public BulletsObjectPool bulletPool;

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
                Fire(0);
            }
        }
    }

    // Fires weapon
    private void Fire(int _level)
    { 
        timestamp = Time.time + (chosenWeapon.rateOfFire / 60);
        GameObject _tempBullet = bulletPool.GetNext(_level);
        _tempBullet.transform.position = bulletSpawnPosition.position;
        _tempBullet.transform.rotation = bulletSpawnPosition.rotation;
        //GameObject _tempBullet = Instantiate(chosenWeapon.weaponEntity, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
    }
}
