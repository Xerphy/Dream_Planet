using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Layer 6 = player, layer 7 = enemy
        if (collision.gameObject.layer != 6 && collision.gameObject.layer != 7) // Destorys bullet if it hits anything besides enemy or player
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 6)   // If bullet hits player, 
        {
            Debug.Log("HIT PLAYER");
            Destroy(gameObject, .05f);
        }
    }
}
