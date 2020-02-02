using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Points = 0;
    public float MaxTape = 100f;
    public float CurrentTape = 100f;

    public Canvas canvas;
    public GameObject announcement;
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
        //StartCoroutine(MakeAnnouncements());
        //MakeAnnouncement(Color.blue, "THIS IS AN ANNOUNCEMENT");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeAnnouncements()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            int i = Random.RandomRange(0, announcements.Length);
            MakeAnnouncement(Color.yellow, announcements[i]);
        }
    }

    public void MakeAnnouncement(Color c, string words = "ANNOUNCEMENT")
    {
        TextMeshProUGUI tmp = announcement.GetComponent<TextMeshProUGUI>();
        tmp.text = words;
        if(c != null)
        {
            tmp.color = c;
        }
        announcement.GetComponent<Animation>().Play();

    }
}
