using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameCreator.Variables;
using UnityEngine.UI;

public class HealthandDamage : MonoBehaviour
{
    public Text UIHealth;

    public int playerHealth = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet" || other.tag == "DeathZone")
        {
            playerHealth -= 1;

            if (playerHealth <= 0)
            {
                SceneManager.LoadScene(1);  //upon dying, the player will be sent back to the hub
                playerHealth = 5;   //health is reset
            }

            UIHealth.text = "Health: " + playerHealth;

            /*
            if (other.tag == "EnemyBullet")
            {
                Destroy(other);
            }
            */
        }
    }
}
