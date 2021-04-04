using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //checkpoint respawn coord
    public Vector3 respawnLocation;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")//if player reaches a checkpoint, then respawnLocation is set to the position of said checkpoint
        {
            respawnLocation = other.transform.position;
        }
        else if (other.tag == "DeathZone")
        {
            transform.position = respawnLocation;//teleport player to last checkpoint when they fall off level
        }
    }
}
