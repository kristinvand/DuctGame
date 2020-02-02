using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthOfTape : MonoBehaviour
{
    [SerializeField]
    GameObject ductTapeBar;

    [SerializeField]
    GameObject ductTapeRefill;

    float emptyRollXValue = 0.0f;
    private Vector3 tapeDeplete = new Vector3(-0.001f, 0, 0f);
    private Vector3 tapeReplenish = new Vector3(0.01f, 0, 0f);

    void Update()
    {
        if (ductTapeBar.transform.localScale.x > emptyRollXValue)
        {
            ductTapeBar.transform.localScale += tapeDeplete;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ductTapeRefill)
        {
            ductTapeBar.transform.localScale += tapeReplenish;
        }
    }

}