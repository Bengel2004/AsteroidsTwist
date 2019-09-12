using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float GetHealth
    {
        get { return health; }
    }
    public float damage;
    [SerializeField]
    protected float health;
    [SerializeField]
    protected EntityType typeOfEntity;
    protected EntityType lastCollidedType;

    protected ObjectPooler SmokePool;

    // checks if entity is damaged
    public virtual void DamageEntity(float damagePoints)
    {
        health -= damagePoints;
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void Awake()
    {
        SmokePool = GameObject.Find("SmokePool").GetComponent<ObjectPooler>();
    }

    // Detects colission with objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject)
        { 
            Entity _tempEntity = collision.transform.gameObject.GetComponent<Entity>();
            //      _tempEntity?.health = health;
            if (_tempEntity != null)
            {
                lastCollidedType = _tempEntity.typeOfEntity;
                DamageEntity(_tempEntity.damage);
            }
        }
    }

    // Spawns particles on destruction and adds score if object is asteroid
    private void OnDisable()
    {
        if (health <= 0)
        {
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        SmokePool.GetNext(0, transform.position, transform.rotation);
    }
}


public enum EntityType
{
    Asteroid,
    LargeAsteroid,
    Projectile,
    Player
}
