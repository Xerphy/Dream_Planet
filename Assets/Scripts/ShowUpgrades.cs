using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpgrades : MonoBehaviour
{
    //public GameObject JP;

    // Start is called before the first frame update
    void Start()
    {
        //JP = GameObject.Find("JP");
       // JP.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        /* if(other.tag == "Jetpack")
         {
             JP.gameObject.SetActive(true);
         }
         else*/

        if(other.tag == "RayGun")
        {
            GameObject FP = GameObject.FindWithTag("FirePoint");
            FP.GetComponent<Gun>().canShoot = true;
            Debug.Log("Can Shoot");
        }
    }
}
