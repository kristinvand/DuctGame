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

    private void Update()
    {
        transform.Rotate(transform.up, rotatationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Add tape
            Instantiate(pickupEffect, transform.position, transform.rotation);

            onPickup.Invoke();

            Destroy(gameObject);
        }
    }
}  