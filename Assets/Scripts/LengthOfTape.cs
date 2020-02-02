using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthOfTape : MonoBehaviour
{
    [SerializeField]
    GameObject ductTapeLength;

    float emptyRollXValue = 0.0001768463f;
    private Vector3 scaleChange = new Vector3(-0.001f, 0, 0f);
    private Vector3 positionChange = new Vector3(0f, 0, 0f);

    void Update()
    {
        if (ductTapeLength.transform.localScale.x > emptyRollXValue){
            ductTapeLength.transform.localScale += scaleChange;
            ductTapeLength.transform.position += positionChange;
        }
    }
}
