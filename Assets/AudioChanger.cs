using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    public string SceneName = "Game";
    // Start is called before the first frame update
    void Start()
    {
        if(AudioManager.instance == null)
        {
            return;
        }
        else
        {
            if(SceneName == "Game")
            {
                AudioManager.instance.SwitchToGameMusic();
            }
            if (SceneName == "MainMenu")
            {
                AudioManager.instance.SwitchToMenuMusic();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
