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

    // Start is called before the first frame update
    void Start()
    {
        UIDialogButtonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("talkedToDingo"))
        {
            speechBubble.SetActive(false);  // Disables the speech bubble once the player has talked to dingo
        }
    }

    void OnTriggerEnter()
    {
        flowchart.SetBooleanVariable("inDingoRange", true);

        UICanvas.SetActive(true);
        //UIPanel.SetActive(true);
        UIDialogButtonText.SetActive(true);
    }

    void OnTriggerExit()
    {
        flowchart.SetBooleanVariable("inDingoRange", false);

        UICanvas.SetActive(false);
        //UIPanel.SetActive(false);
        UIDialogButtonText.SetActive(false);
    }
}
