using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMoving : MonoBehaviour
{
    public float roomScrollSpeed = 0.1f;

    void Update()
    {
        transform.position += new Vector3(0, 0, roomScrollSpeed);

        if (transform.position.z < -50f)
            Destroy(gameObject);
    }
}