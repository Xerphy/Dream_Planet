using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameCreator.Variables;
using UnityEngine.UI;

public class HealthandDamage : MonoBehaviour
{
    //checkpoint respawn coord
    public Vector3 respawnLocation;

    public Text UIHealth;

    public int playerHealth = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")  //if player reaches a checkpoint, then respawnLocation is set to the position of said checkpoint
        {
            respawnLocation = other.transform.position;
        }
        else if (other.tag == "EnemyBullet")
        {
            if (playerHealth <= 0)
            {
                SceneManager.LoadScene(2);  //upon dying, the player will be sent back to the hub
                playerHealth = 5;   //health is reset
            }

            UIHealth.text = "Health: " + playerHealth;
            playerHealth -= 1;
        }
        else if (other.tag == "DeathZone")
        {
            transform.position = respawnLocation;//teleport player to last checkpoint when they fall off level

            if (playerHealth <= 0)
            {
                SceneManager.LoadScene(2);  //upon dying, the player will be sent back to the hub
                playerHealth = 5;   //health is reset
            }

            UIHealth.text = "Health: " + playerHealth;
            playerHealth -= 1;
        }
    }
}
