using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEndStats : MonoBehaviour
{
    public static DisplayEndStats instance;

    public Text cracksMissed;
    public Text men;
    public Text woman;
    public Text children;
    public Text cracksFilled;
    public Text ventsHit;
    public Text ductTapeCollected;
    public Text finalScore;

    public int IcracksMissed;
    public int Imen;
    public int Iwoman;
    public int Ichildren;
    public int IcracksFilled;
    public int IventsHit;
    public int IductTapeCollected;
    public int IfinalScore;
    
    public int men_dead;
    public int woman_dead;
    public int children_dead;

    public bool canUpdateNums = false;

    private bool rollDeadPeeps = false;

    private void Start()
    {
        instance = this;

        cracksMissed.text = "Cracks Missed: 0";
        men.text = "0 Men";
        woman.text = "0 Woman";
        children.text = "0 Children";
        cracksFilled.text = "Cracks Filled: 0";
        ventsHit.text = "Vents Hit: 0";
        ductTapeCollected.text = "Duct Tape Collected: 0";
        finalScore.text = "0";
    }

    public void Update()
    {
        if (canUpdateNums)
        {
            if(!rollDeadPeeps)
            {
                rollDeadPeeps = true;

                men_dead = Random.Range(1, 9) * DuctManController.instance.stats.cracksMissed;
                woman_dead = Random.Range(1, 7) * DuctManController.instance.stats.cracksMissed;
                children_dead = Random.Range(1, 4) * DuctManController.instance.stats.cracksMissed;

                if (DuctManController.instance.stats.cracksMissed >= DuctManController.instance.stats.cracksFilled)
                {
                    AudioManager.instance.audioSource.volume = 0.1f;
                    GetComponent<AudioSource>().Play();
                }
            }

            if (IcracksMissed < DuctManController.instance.stats.cracksMissed)
                IcracksMissed = Mathf.Clamp(IcracksMissed + 1, 0, DuctManController.instance.stats.cracksMissed);

            if (IcracksFilled < DuctManController.instance.stats.cracksFilled)
                IcracksFilled = Mathf.Clamp(IcracksFilled + 1, 0, DuctManController.instance.stats.cracksFilled);

            if (IventsHit < DuctManController.instance.stats.ventsHit)
                IventsHit = Mathf.Clamp(IventsHit + 1, 0, DuctManController.instance.stats.ventsHit);

            if (IductTapeCollected < DuctManController.instance.stats.ductTapeCollected)
                IductTapeCollected = Mathf.Clamp(IductTapeCollected + 1, 0, DuctManController.instance.stats.ductTapeCollected);

            if (IfinalScore < GameManager.instance.Points)
                IfinalScore = Mathf.Clamp(IfinalScore + 10, 0, GameManager.instance.Points);

            if (Imen < men_dead)
                Imen = Mathf.Clamp(Imen + 1, 0, men_dead);

            if (Iwoman < woman_dead)
                Iwoman = Mathf.Clamp(Iwoman + 1, 0, woman_dead);

            if (Ichildren < children_dead)
                Ichildren = Mathf.Clamp(Ichildren + 1, 0, children_dead);

            cracksMissed.text = "Cracks Missed: " + IcracksMissed;


            if(Imen == 1)
                men.text = Imen + " Man";
            else men.text = Imen + " Men";

            if (Iwoman == 1)
                woman.text = Iwoman + " Woman";
            else woman.text = Iwoman + " Women";

            if (Ichildren == 1)
                children.text = Ichildren + " Child";
            else children.text = Ichildren + " Children";

            cracksFilled.text = "Cracks Filled: " + IcracksFilled;
            ventsHit.text = "Vents Hit: " + IventsHit;
            ductTapeCollected.text = "Duct Tape Collected: " + IductTapeCollected;
            finalScore.text = "" + IfinalScore;
        }
    }
}