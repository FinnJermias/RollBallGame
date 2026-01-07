using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            player.transform.position = respawnPoint.position;
        }
    }
}
