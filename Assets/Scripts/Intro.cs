using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    float timeLeft = 31.0f;//31 seconds for intro cutscene

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0 || Input.GetKeyDown(KeyCode.Return))//if video ends or player presses enter to skip, move to hub scene
        {
            SceneManager.LoadScene(1);//load to hub
        }
    }
}
