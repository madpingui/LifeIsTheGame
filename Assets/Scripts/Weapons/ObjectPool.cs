using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPool: MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;
    [NonSerialized]public List<GameObject> pool = new List<GameObject>();
}
