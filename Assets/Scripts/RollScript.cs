using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollScript : MonoBehaviour
{
    Rigidbody rb;
    public int velocity = 3;
    public float force = 2f;
    public float speedLimit = 40f;
    public TMP_Text speedNow;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        float speed = rb.velocity.magnitude; // Current speed
        speedNow.text = "Speed: " + speed.ToString("F2");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        rb.AddForce(move * force);

        if (rb.velocity.magnitude > speedLimit) // .magnitude means velocity to all direction x,y,z
        {

            rb.velocity = rb.velocity.normalized * speedLimit; // .normalized means that it removes velocity from our player and only getting the direction 

        }
    }
}