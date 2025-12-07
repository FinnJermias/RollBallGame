using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudScript : MonoBehaviour
{
   
    public float mudFactor = 5f;           // Higher = stickier mud
    public float playerForceMultiplier = 0.5f; // Reduce ball force inside mud

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            RollScript roll = other.GetComponent<RollScript>();

            if (rb != null)
            {
                if (rb.velocity.magnitude > 0.01f) // avoid divide by zero
                {
                    Vector3 resistForce = -rb.velocity.normalized * mudFactor * rb.velocity.magnitude;
                    rb.AddForce(resistForce, ForceMode.Acceleration);
                }
            }

            if (roll != null)
            {
                // Reduce player's input force while in mud
                roll.force *= playerForceMultiplier;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RollScript roll = other.GetComponent<RollScript>();
            if (roll != null)
            {
                // Restore normal force when leaving mud
                roll.force /= playerForceMultiplier;
            }
        }
    }
}
