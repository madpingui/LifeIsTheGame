using System.Collections;
using UnityEngine;

//Class to create the pool of magentic spheres
public class SphereSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int numberOfObjectsToSpawn = 10;
    public float spawnDelay = 0.1f;

    void Start() => StartCoroutine(SpawnObjectsWithDelay());

    IEnumerator SpawnObjectsWithDelay()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
