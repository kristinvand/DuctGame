using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Points = 0;
    public float MaxTape = 100f;
    public float CurrentTape = 100f;

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
        
    }

    IEnumerator DisableParticles()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ParticleSystem[] PS = FindObjectsOfType<ParticleSystem>();
            for(int i = 0; i < PS.Length; i++)
            {
                Destroy(PS[i]);
            }
        }
    }
}
