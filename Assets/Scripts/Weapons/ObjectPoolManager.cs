using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;
    public List<ObjectPool> objectPools;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeObjectPools();
        }
        else
            Destroy(gameObject);
    }

    void InitializeObjectPools()
    {
        foreach (var pool in objectPools)
            CreateObjectPool(pool);
    }

    void CreateObjectPool(ObjectPool poolObject)
    {
        for (int i = 0; i < poolObject.poolSize; i++)
        {
            var obj = Instantiate(poolObject.prefab, poolObject.transform);
            obj.SetActive(false);
            poolObject.pool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool(int poolIndex, Vector3 position, Quaternion rotation)
    {
        var pool = objectPools[poolIndex].pool;

        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        // If no inactive objects found, create a new one and add it to the pool
        var newObj = Instantiate(objectPools[poolIndex].prefab, position, rotation, objectPools[poolIndex].transform);
        pool.Add(newObj);
        return newObj;
    }
}
