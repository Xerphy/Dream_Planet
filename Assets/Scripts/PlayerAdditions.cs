using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdditions : MonoBehaviour
{
    //checkpoint respawn coord
    public Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")  //if player reaches a checkpoint, then respawnLocation is set to the position of said checkpoint
        {
            respawnLocation = other.transform.position;
        }
        else if (other.tag == "DeathZone")
        {
            transform.position = respawnLocation;   //teleport player to last checkpoint when they fall off level
        }
    }
}

