using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public enum PlayerRunwayPosition
{
    Default = 0,
    Left,
    Center,
    Right
}

public class DuctManController : MonoBehaviour
{
    public float ForwardVelocity = 1f;
    public float CameraDistance = 3f;
    public Camera MainCameraReference;
    public PlayerRunwayPosition PlayerPosition = PlayerRunwayPosition.Center;
    public Transform DuctTapeOuterTransform;
    public float TapeRotationalVelocityZ = 1f;

    private Transform cameraTransform = null; 
    private Transform playerTransform = null;
    private float playerPositionX = 0f;
    private PlayerRunwayPosition lastPosition = PlayerRunwayPosition.Default;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = MainCameraReference.transform;
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPosition != PlayerPosition)
        {
            lastPosition = PlayerPosition;
            switch (PlayerPosition)
            {
                case PlayerRunwayPosition.Left:
                    playerPositionX = -2.25f;
                    break;
                case PlayerRunwayPosition.Center:
                    playerPositionX = 0f;
                    break;
                case PlayerRunwayPosition.Right:
                    playerPositionX = 2.25f;
                    break;

            }
        }

        if (playerTransform.position.x != playerPositionX)
        {
            playerTransform.position = new Vector3(playerPositionX, playerTransform.position.y, playerTransform.position.z);
        }

        // update player & camera translation
        playerTransform.position += new Vector3(0.0f, 0.0f, ForwardVelocity);
        cameraTransform.position = new Vector3(playerPositionX, cameraTransform.position.y, playerTransform.position.z - CameraDistance);

        //todo: this could be a function of player movement
        DuctTapeOuterTransform.Rotate(new Vector3(0f, 0f, -TapeRotationalVelocityZ));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var directionalMovement = context.ReadValue<Vector2>();
            var movementX = directionalMovement.x;

            if (movementX > 0 && PlayerPosition < PlayerRunwayPosition.Right)
            {
                PlayerPosition += 1;
            }
            else if (movementX < 0 && PlayerPosition > PlayerRunwayPosition.Left)
            {
                PlayerPosition -= 1;
            }
        }
    }
}