using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowHitEffect : MonoBehaviour
{
    public ParticleSystem snowHitEffect;
    public GameObject ParticleSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Snowball"))
        {
            ParticleSystem hiteffsnow = Instantiate(snowHitEffect, ParticleSpawn.transform.position, Quaternion.identity, ParticleSpawn.transform); //creates game object hiteff
            Destroy(hiteffsnow.gameObject, 1f); // destroy 
        }
    }
}
