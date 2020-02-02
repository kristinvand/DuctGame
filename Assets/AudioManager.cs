using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager instance { get { return _instance; } }

    public AudioClip MenuMusic;
    public AudioClip GameMusic;
    public float fadeTime = 2f;
    public float stepTime = 0.1f;

    AudioSource audioSource;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void SwitchToGameMusic()
    {
        StartCoroutine(FadeAudio(GameMusic));
    }

    public void SwitchToMenuMusic()
    {
        StartCoroutine(FadeAudio(MenuMusic));
    }

    IEnumerator FadeAudio(AudioClip newAudio)
    {

        for(int i = 0; i < fadeTime/ stepTime; i++)
        {
            audioSource.volume -= 1 / (fadeTime / stepTime);
            yield return new WaitForSeconds(stepTime);
        }
        audioSource.Stop();
        audioSource.clip = newAudio;
        audioSource.Play();
        for (int i = 0; i < fadeTime / stepTime; i++)
        {
            audioSource.volume += 1 / (fadeTime / stepTime);
            yield return new WaitForSeconds(stepTime);
        }
        audioSource.volume = 1;

    }
}
