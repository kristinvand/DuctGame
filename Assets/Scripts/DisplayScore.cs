using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI tmp;
    Text txt;

    // Start is called before the first frame upda
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();

        if (!tmp)
            txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tmp)
            tmp.text = "Score: " + GameManager.instance.Points;
        else if(txt)
            txt.text = "Score: " + GameManager.instance.Points;
    }
}
