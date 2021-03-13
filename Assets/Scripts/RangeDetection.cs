using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RangeDetection : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject speechBubble;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    void OnTriggerExit()
    {
        flowchart.SetBooleanVariable("inDingoRange", false);
    }
}
