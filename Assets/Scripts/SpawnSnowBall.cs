using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowBall : MonoBehaviour
{
    public GameObject snowballPrefab;
    public Transform SpawnPoint;
    public bool checkspawn = true;

    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnRoutine()); //startcoroutine says hey start this method
                                        //i have and dont stop until a stopCoroutine is added or checkspawn turns false
    }

    IEnumerator SpawnRoutine() //IEnumerator means that the method can pause and continue
    {
        while (checkspawn == true)
        {
            yield return new WaitForSeconds(spawnInterval); // Waits for the amount of time placed and then execute the next code
            SpawnFromSky();
        }
    }

    void SpawnFromSky()
    {
        GameObject snowball = Instantiate(snowballPrefab,SpawnPoint.position,SpawnPoint.rotation);
        Destroy(snowball, 12f);
    }
}