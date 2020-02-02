using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LengthOfTape : MonoBehaviour
{
    public static float rollFillCurrent = 0.0f;
    public Image ductTapeBar;
    public static float rollFillMax = 100.0f;

    private void Start()
    {
        rollFillCurrent = rollFillMax;
    }

    void Update()
    {
        rollFillCurrent = Mathf.Clamp(rollFillCurrent, 0, rollFillMax);
        ductTapeBar.fillAmount = Mathf.Lerp(ductTapeBar.fillAmount, rollFillCurrent / rollFillMax, 0.1f);
    }
}