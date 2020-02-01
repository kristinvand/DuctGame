using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DucBoiController : MonoBehaviour
{
    public float ForwardVelocity = 1f;
    public float CameraDistance = 3f;
    public Camera MainCameraReference;

    private Transform cameraTransform = null; 
    private Transform playerTransform = null;

    private int currentPlayerSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = MainCameraReference.transform;
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // update player & camera translation
        playerTransform.position += new Vector3(0.0f, 0.0f, ForwardVelocity);
        cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, playerTransform.position.z - CameraDistance);
    }
}
