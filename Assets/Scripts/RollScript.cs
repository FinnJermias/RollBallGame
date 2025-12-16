using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollScript : MonoBehaviour
{
    Rigidbody rb;
    public float force = 3f;
    public float startForce;
    public float speedLimit = 60f;
    public TMP_Text speedNow;

    public GameObject hitEffect;
    public GameObject mudEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startForce = force;

        hitEffect.SetActive(false);
        mudEffect.SetActive(false);
    }

    void Update()
    {
        float currentSpeed = rb.velocity.magnitude;
        speedNow.text = "Speed: " + currentSpeed.ToString("F2");
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        rb.AddForce(move * force, ForceMode.Acceleration);

        // Proper speed limit (does NOT kill A/D)
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (flatVel.magnitude > speedLimit)
        {
            Vector3 limitedVel = flatVel.normalized * speedLimit;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void SetForceMultiplier(float multiplier)
    {
        force = startForce * multiplier;
    }

    public void ResetForce()
    {
        force = startForce;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            hitEffect.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mud"))
        {
            mudEffect.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mud"))
        {
            mudEffect.SetActive(false);
        }
    }
}
