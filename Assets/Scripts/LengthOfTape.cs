using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LengthOfTape : MonoBehaviour
{
    public static float rollFillCurrent = 0.0f;

    public Image ductTapeBar;
    
    float rollFillMax = 100.0f;

    private Vector3 tapeDeplete = new Vector3(-0.001f, 0, 0f);
    private Vector3 tapeReplenish = new Vector3(0.01f, 0, 0f);

    private void Start()
    {
        rollFillCurrent = rollFillMax;
    }

    void Update()
    {
        rollFillCurrent = Mathf.Clamp(rollFillCurrent, 0, rollFillMax);

        ductTapeBar.fillAmount = Mathf.Lerp(ductTapeBar.fillAmount, rollFillCurrent / rollFillMax, 0.1f);
        
        //if (ductTapeBar.transform.localScale.x > emptyRollXValue)
        //{
        //    ductTapeBar.transform.localScale += tapeDeplete;
        //}
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == ductTapeRefill)
    //    {
    //        ductTapeBar.transform.localScale += tapeReplenish;
    //    }
    //}

}