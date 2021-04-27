using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RangeDetection : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject speechBubble;
    public GameObject UICanvas;
    //public GameObject UIPanel;
    public GameObject UIDialogButtonText;

    public string talkedToNPC;
    public string inNPCRange;

    // Start is called before the first frame update
    void Start()
    {
        UIDialogButtonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable(talkedToNPC))  //"talkedToDingo"
        {
            speechBubble.SetActive(false);  // Disables the speech bubble once the player has talked to a specific NPC
        }
    }

    void OnTriggerEnter()
    {
        flowchart.SetBooleanVariable(inNPCRange, true); //"inDingoRange"

        UICanvas.SetActive(true);
        UIDialogButtonText.SetActive(true);
    }

    void OnTriggerExit()
    {
        flowchart.SetBooleanVariable(inNPCRange, false);    //"inDingoRange"

        UICanvas.SetActive(false);
        UIDialogButtonText.SetActive(false);
    }
}
