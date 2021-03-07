using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RangeDetection : MonoBehaviour
{
    public Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
