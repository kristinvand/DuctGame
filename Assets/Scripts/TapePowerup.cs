using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TapePowerup : MonoBehaviour
{
    public float refillAmount;

    public float rotatationSpeed = 1.0f;

    public GameObject pickupEffect;

    public UnityEvent onPickup = new UnityEvent();

    public List<AudioClip> audioClips = new List<AudioClip>();

    private void Update()
    {
        transform.Rotate(transform.up, rotatationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Add tape
            LengthOfTape.rollFillCurrent += 25f;
            AudioManager.instance.PlaySound("TapePickUp");
            GameManager.instance.MakeAnnouncement(Color.green, "Tape reload!");
            GameManager.instance.FlashScreen(Color.green);

            DuctManController.instance.stats.ductTapeCollected++;
            GameManager.instance.AddPoints(45);

            if (audioClips.Count > 0)
            {
                if (Random.Range(0, 100) < 25)
                {
                    if (DuctManController.instance.audioSource.isPlaying)
                    {
                        DuctManController.instance.audioSource.Stop();
                    }
                    DuctManController.instance.audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count - 1)]);
                }
            }

            Instantiate(pickupEffect, transform.position, transform.rotation);

            onPickup.Invoke();

            Destroy(gameObject);
        }
    }
}