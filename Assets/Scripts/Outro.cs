using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameCreator.Variables;
using Fungus;

public class Outro : MonoBehaviour
{
    float timeLeft = 45.0f;//38 seconds for outro cutscene
    public Flowchart flowchart;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 || Input.GetKeyDown(KeyCode.Return))//if video ends or player presses enter to skip, move to menu scene
        {
            //Resets all gameplay variables (basically restarts the game but keeps volume levels)
            VariablesManager.SetGlobal("CollectedPiece1", 0f);
            VariablesManager.SetGlobal("CollectedPiece2", 0f);
            VariablesManager.SetGlobal("CollectedPiece3", 0f);
            VariablesManager.SetGlobal("CollectedPiece4", 0f);
            VariablesManager.SetGlobal("CollectedPiece5", 0f);
            VariablesManager.SetGlobal("CollectedPiece6", 0f);
            VariablesManager.SetGlobal("CollectedPiece7", 0f);
            VariablesManager.SetGlobal("CollectedPieces", 0f);
            flowchart.SetBooleanVariable("talkedToDingo", false);
            flowchart.SetBooleanVariable("talkedToGoanna", false);

            SceneManager.LoadScene(0);//load to menu
        }
    }
}