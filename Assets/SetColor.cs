using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public Material RedSkin;
    public Material BlueSkin;
    public Material ZebraSkin;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        string colorchoice = PlayerPrefs.GetString("Color", "Duct");
        switch (colorchoice)
        {
            case "Red":
                MR.material = RedSkin;
                break;
            case "Blue":
                MR.material = BlueSkin;
                break;
            case "Zebra":
                MR.material = ZebraSkin;
                break;
            default:
                break;
        }
    }
}
