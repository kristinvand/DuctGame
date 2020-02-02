using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Points = 0;
    public float rollFillMax = LengthOfTape.rollFillMax;
    public float rollFillCurrent = LengthOfTape.rollFillCurrent;
    //MainMenuController mainMenuController;
    public float StartingRoomScrollSpeed = 0.15f;

    public Canvas canvas;
    public GameObject announcement;
    public GameObject ScreenFlash;
    string[] announcements = new string[]
    {
        "Mega time!",
        "Speed speed!!!",
        "Never stop!",
        "Tape it down!",
        "UH OH!",
        "STOP PLAYING",
        "NEVER!",
        "Tape time!!!"
    };

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddPoints(int delta)
    {
        Points += delta;
    }
    // Start is called before the first frame update
    void Start()
    {
        RoomMoving.roomScrollSpeed = StartingRoomScrollSpeed;
        //StartCoroutine(MakeAnnouncements());
        //MakeAnnouncement(Color.blue, "THIS IS AN ANNOUNCEMENT");
    }

    // Update is called once per frame
    void Update()
    {
        rollFillCurrent = LengthOfTape.rollFillCurrent;
        rollFillMax = LengthOfTape.rollFillMax;

        if (rollFillCurrent <= 0)
        {
            SceneManager.LoadScene(0);
            //mainMenuController.TriggerCredits(true);
        }
    }

    IEnumerator MakeAnnouncements()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            int i = Random.RandomRange(0, announcements.Length);
            MakeAnnouncement(Color.yellow, announcements[i]);
            FlashScreen(Color.red);
        }
    }

    public void MakeAnnouncement(Color c, string words = "ANNOUNCEMENT")
    {
        TextMeshProUGUI tmp = announcement.GetComponent<TextMeshProUGUI>();
        tmp.text = words;
        if (c != null)
        {
            tmp.color = c;
        }
        announcement.GetComponent<Animation>().Play();

    }

    public void FlashScreen(Color c)
    {

        Image image = ScreenFlash.GetComponent<Image>();
        Animation anim = ScreenFlash.GetComponent<Animation>();
        image.color = c;
        anim.Play();
    }


}