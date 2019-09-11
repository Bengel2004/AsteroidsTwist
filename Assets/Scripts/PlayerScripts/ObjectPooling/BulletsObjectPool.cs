using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsObjectPool : MonoBehaviour
{

    [SerializeField]
    private List<Bullets> pool;

    [SerializeField]
    private GameObject[] prefabs;
    private int currentIndex = 0;

    [SerializeField]
    private int size;

    private int spawnIndex;

    private void Start()
    {
        pool = new List<Bullets>(4);
        foreach (GameObject prefab in prefabs)
        {
            Bullets _temp = new Bullets();
            pool.Add(_temp);
        }

        Debug.Log(pool.Count + " POOL COUNT");
        // pool[currentIndex] = new List<GameObject>(size);
        ObjectPool(size);
    }

    public void ObjectPool(int size)
    {
        foreach (GameObject prefab in prefabs) {

            pool[spawnIndex].bullets = new List<GameObject>(size);
            for (int i = 0; i < size; ++i)
            {
                Spawn();
            }
            spawnIndex += 1;

        }
    }

    public GameObject GetNext(int _level)
    {
        GameObject obj = pool[_level].bullets[currentIndex];
        currentIndex = ++currentIndex % pool.Count;
        obj.SetActive(true);
        return obj;
    }

    private void Spawn()
    {
        GameObject obj = Object.Instantiate(prefabs[spawnIndex]);
        obj.SetActive(false);
        pool[spawnIndex].bullets.Add(obj);
    }
}
[System.Serializable]
public class Bullets
{
    public List<GameObject> bullets;
}