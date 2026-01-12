using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollScript : MonoBehaviour
{
    Rigidbody rb;
    public float force = 3.5f;
    public float startForce = 0f;
    public float speedLimit = 60f;
    public TMP_Text speedNow;

    public ParticleSystem hitEffect;
    public ParticleSystem mudEffect;
    private ParticleSystem activatemud;
    public GameObject ParticleSpawn;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startForce = force; //we use this because we want to make sure startforce is exactly the same as the force currently
    }

    void Update()
    {
        float currentSpeed = rb.velocity.magnitude; //grabs total of velocity
        speedNow.text = "Speed: " + currentSpeed.ToString("F2"); 
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical"); //front or back
        float horizontal = Input.GetAxis("Horizontal"); //sides

        Vector3 move = new Vector3(horizontal, 0, vertical);
        rb.AddForce(move * force, ForceMode.Force); //using ForceMode.Force allows AddForce to take mass into consideration

        // Speed limit
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);  //gets current speed with and without inputs
        if (flatVel.magnitude > speedLimit) //checks if total velocity is more than speedlimit
        {
            Vector3 limitedVel = flatVel.normalized * speedLimit; // make the velocity move at a limited rate 
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); //change rigidbody velocity with the limited velocity
        }
    }

   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
           ParticleSystem hiteff = Instantiate(hitEffect, ParticleSpawn.transform.position, Quaternion.identity); //creates game object hiteff
            Destroy(hiteff.gameObject, 1f); // destroy 
        }
        
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Mud"))
        {
            if (activatemud == null)
            {
                activatemud = Instantiate(mudEffect, ParticleSpawn.transform.position, Quaternion.identity, ParticleSpawn.transform);
               
            }
            activatemud.Play();
        }
    }
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.CompareTag("Mud"))
        {
            if (activatemud != null)
            {
                activatemud.Stop();
                Destroy(activatemud.gameObject, 1f);
                activatemud = null;
            }
           
        }
    }
}
