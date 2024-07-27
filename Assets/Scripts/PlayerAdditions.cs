using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCreator.Variables;

public class PlayerAdditions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        WebGLInput.stickyCursorLock = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

