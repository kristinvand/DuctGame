using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMoving : MonoBehaviour
{
    public static float roomScrollSpeed = 0.15f;

    private void Start()
    {
        //roomScrollSpeed = 0.15f;
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, -roomScrollSpeed + (DuctManController.instance.isTaping ? 0.1f : 0f));

        if (transform.position.z < -50f)
        {
            RoomSpawning.canSpawn = true;
            Destroy(gameObject);
        }
    }
}