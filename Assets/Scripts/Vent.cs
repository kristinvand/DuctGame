using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector3 rotationAxis;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles + (rotationAxis * speed));
    }
}