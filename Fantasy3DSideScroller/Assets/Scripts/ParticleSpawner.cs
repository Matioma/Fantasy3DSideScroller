using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject collectiblePrefab;

    [SerializeField]
    float explosionForse;
    [Range(0,5)]
    [SerializeField]
    float spawnRange;


    public void SpawnParticles(int count) {
        for (int i = 0; i < count; i++) {
            SpawnParticle();
        }
    }

    void SpawnParticle()
    {
        GameObject obj = Instantiate(collectiblePrefab);
        Vector3 randomOffsetVector = new Vector3(0, Random.Range(0, spawnRange), Random.Range(-spawnRange, spawnRange));


        obj.transform.position =transform.position;
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody?.AddExplosionForce(explosionForse, transform.position- randomOffsetVector, spawnRange);
    }

}
