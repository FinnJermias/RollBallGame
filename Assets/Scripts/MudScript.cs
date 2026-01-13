using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudScript : MonoBehaviour
{
    public float mudDrag = 6f; //controls mud slowness
    private float originalDrag ; //players original drag

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Rigidbody rb = player.GetComponent<Rigidbody>(); //gets player rigidbody
            if (rb != null)
            {
                originalDrag = rb.drag; // stores players drag onto original drag to remember
                rb.drag = mudDrag; // change player drag to muddrag
            }

            RollScript roll = player.GetComponent<RollScript>();
            if (roll != null)
            {
                roll.force = roll.startForce * 0.5f; //reduces player input
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.drag = originalDrag; //returns player drag
            }

            RollScript roll = player.GetComponent<RollScript>();
            if (roll != null)
            {
                roll.force = roll.startForce; //returns player force
            }
        }
    }
}
