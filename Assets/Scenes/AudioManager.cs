using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager instance { get { return _instance; } }

    public AudioClip MenuMusic;
    public AudioClip GameMusic;
    public float fadeTime = 2f;
    public float stepTime = 0.1f;

    AudioSource audioSource;

    AudioSource[] otherSounds;


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
        otherSounds = GetComponentsInChildren<AudioSource>();
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
        yield return new WaitForSeconds(stepTime);
        for (int i = 0; i < fadeTime/ stepTime; i++)
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    public void PlaySound(string SoundName)
    {
        for(int i = 0; i < otherSounds.Length; i++)
        {
            if(otherSounds[i].gameObject.name == SoundName)
            {
                otherSounds[i].Play();
                return;
            }
        }
    }
}
