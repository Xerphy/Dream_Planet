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

    public Image UIHealthImage;

    public Sprite hearts6;
    public Sprite hearts5;
    public Sprite hearts4;
    public Sprite hearts3;
    public Sprite hearts2;
    public Sprite hearts1;
    public Sprite hearts0;

    public int playerHealth = 6;

    private void Update()
    {
        if (playerHealth == 6)
            UIHealthImage.sprite = hearts6;
        else if (playerHealth == 5)
            UIHealthImage.sprite = hearts5;
        else if (playerHealth == 4)
            UIHealthImage.sprite = hearts4;
        else if (playerHealth == 3)
            UIHealthImage.sprite = hearts3;
        else if (playerHealth == 2)
            UIHealthImage.sprite = hearts2;
        else if (playerHealth == 1)
            UIHealthImage.sprite = hearts1;
        else if (playerHealth == 0)
            UIHealthImage.sprite = hearts0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")  //if player reaches a checkpoint, then respawnLocation is set to the position of said checkpoint
        {
            respawnLocation = other.transform.position;
        }
        else if (other.tag == "EnemyBullet")
        {
            if (playerHealth <= 1)
            {
                SceneManager.LoadScene(2);  //upon dying, the player will be sent back to the hub
                playerHealth = 6;   //health is reset
            }

            playerHealth -= 1;
        }
        else if (other.tag == "DeathZone")
        {
            transform.position = respawnLocation;//teleport player to last checkpoint when they fall off level

            if (playerHealth <= 2)
            {
                SceneManager.LoadScene(2);  //upon dying, the player will be sent back to the hub
                playerHealth = 6;   //health is reset
            }

            playerHealth -= 1;
        }
    }
}
