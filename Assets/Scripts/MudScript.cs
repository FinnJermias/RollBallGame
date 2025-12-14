using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudScript : MonoBehaviour
{
    public float mudDrag = 6f;
    private float originalDrag;

    private void OnTriggerEnter(Collider player)
    {
        if (!player.CompareTag("Player")) return;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            originalDrag = rb.drag;
            rb.drag = mudDrag;
        }

        RollScript roll = player.GetComponent<RollScript>();
        if (roll != null)
        {
            roll.force = roll.startForce * 0.5f;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (!player.CompareTag("Player")) return;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.drag = originalDrag;
        }

        RollScript roll = player.GetComponent<RollScript>();
        if (roll != null)
        {
            roll.force = roll.startForce; 
        }
    }
}
