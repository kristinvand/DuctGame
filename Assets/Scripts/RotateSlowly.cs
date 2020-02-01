using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlowly : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1 * speed, 0));
    }
}
