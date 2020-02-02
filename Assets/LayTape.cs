using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayTape : MonoBehaviour
{
    LineRenderer LR;

    public void Start()
    {
        LR = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            EnableTape();
        }
        if (Input.GetKeyUp("t"))
        {
            DisableTape();
        }
    }

    public void EnableTape()
    {
        LR.enabled = true;
    }

    public void DisableTape()
    {
        LR.enabled = false;
    }
}
