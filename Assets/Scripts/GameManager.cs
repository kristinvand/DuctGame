using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    MainMenuController mainMenuController;
    public int Points = 0;
    public float rollFillMax = LengthOfTape.rollFillMax;
    public float rollFillCurrent = LengthOfTape.rollFillCurrent;

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
        //StartCoroutine(DisableParticles());
    }

    // Update is called once per frame
    void Update()
    {
        rollFillCurrent = LengthOfTape.rollFillCurrent;
        rollFillMax = LengthOfTape.rollFillMax;

        if (rollFillCurrent <= 0)
        {
            SceneManager.LoadScene(0);
            mainMenuController.TriggerCredits(true);
        }
    }

    IEnumerator DisableParticles()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ParticleSystem[] PS = FindObjectsOfType<ParticleSystem>();
            for (int i = 0; i < PS.Length; i++)
            {
                Destroy(PS[i]);
            }
        }
    }
}