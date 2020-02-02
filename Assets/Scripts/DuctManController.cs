using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public enum PlayerRunwayPosition
{
    Left = 0,
    Center,
    Right
}

public class DuctManController : MonoBehaviour
{
    public float ForwardVelocity = 1f;
    public float CameraDistance = 3f;
    public Camera MainCameraReference;
    public int PlayerPosition = 0;
    public Transform DuctTapeOuterTransform;
    public float TapeRotationalVelocityZ = 1f;
    public float changeLaneDelay = 2.0f;
    public float changeLaneSpeed = 0.1f;

    private Transform cameraTransform = null; 
    private Transform playerTransform = null;
    private float playerPositionX = 0f;
    private float playerPositionY = 0f;
    private Vector3 playerRotation = Vector3.zero;
    private int lastPosition = 0;
    private float timeSinceLaneChange = 0f;

    private readonly Vector3 downRotation = Vector3.zero;
    private readonly Vector3 leftRotation = new Vector3(0, 0, -90);
    private readonly Vector3 upRotation = new Vector3(0, 0, -180);
    private readonly Vector3 rightRotation = new Vector3(0, 0, 90);

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = MainCameraReference.transform;
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLaneChange += Time.deltaTime;

        switch (PlayerPosition)
        {
            case 0:
                playerPositionX = 0f;
                playerPositionY = 0f;
                playerRotation = downRotation;
                break;
            case 1:
                playerPositionX = -2f;
                playerPositionY = 0f;
                playerRotation = downRotation;
                break;
            case 2:
                playerPositionX = -4f;
                playerPositionY = 0f;
                playerRotation = downRotation;
                break;
            case 3:
                playerPositionX = -6f;
                playerPositionY = 0f;
                playerRotation = downRotation;
                break;
            case 4:
                playerPositionX = -7.55f;
                playerPositionY = 1f;
                playerRotation = leftRotation;
                break;
            case 5:
                playerPositionX = -7.55f;
                playerPositionY = 3f;
                playerRotation = leftRotation;
                break;
            case 6:
                playerPositionX = -7.55f;
                playerPositionY = 4.5f;
                playerRotation = leftRotation;
                break;
            case 7:
                playerPositionX = -7.55f;
                playerPositionY = 6.25f;
                playerRotation = leftRotation;
                break;
            case 8:
                playerPositionX = -7.55f;
                playerPositionY = 7f;
                playerRotation = leftRotation;
                break;
            case 9:
                playerPositionX = -4.5f;
                playerPositionY = 9f;
                playerRotation = upRotation;
                break;
            case 10:
                playerPositionX = -2.25f;
                playerPositionY = 9f;
                playerRotation = upRotation;
                break;
            case 11:
                playerPositionX = 0f;
                playerPositionY = 9f;
                playerRotation = upRotation;
                break;
            case 12:
                playerPositionX = 2.25f;
                playerPositionY = 9f;
                playerRotation = upRotation;
                break;
            case 13:
                playerPositionX = 4.5f;
                playerPositionY = 9f;
                playerRotation = upRotation;
                break;
            case 14:
                playerPositionX = 6.25f;
                playerPositionY = 9f;
                playerRotation = upRotation;
                break;
            case 15:
                playerPositionX = 7.5f;
                playerPositionY = 7.5f;
                playerRotation = rightRotation;
                break;
            case 16:
                playerPositionX = 7.5f;
                playerPositionY = 6.5f;
                playerRotation = rightRotation;
                break;
            case 17:
                playerPositionX = 7.5f;
                playerPositionY = 4.5f;
                playerRotation = rightRotation;
                break;
            case 18:
                playerPositionX = 7.5f;
                playerPositionY = 1.25f;
                playerRotation = rightRotation;
                break;
            case 19:
                playerPositionX = 6.25f;
                playerPositionY = 0f;
                playerRotation = downRotation;
                break;
            case 20:
                playerPositionX = 4.75f;
                playerPositionY = 0f;
                playerRotation = downRotation;
                break;
            case 21:
                playerPositionX = 2.5f;
                playerPositionY = 0f;
                playerRotation = downRotation;
                break;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(playerPositionX, playerPositionY, -6.066026f), changeLaneSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(playerRotation), changeLaneSpeed);
        //Quaternion.Euler(playerRotation)

        #region Old system
        //if (lastPosition != PlayerPosition)
        //{
        //    lastPosition = PlayerPosition;
        //    //switch (PlayerPosition)
        //    //{
        //    //    case PlayerRunwayPosition.Left:
        //    //        playerPositionX = -2.25f;
        //    //        break;
        //    //    case PlayerRunwayPosition.Center:
        //    //        playerPositionX = 0f;
        //    //        break;
        //    //    case PlayerRunwayPosition.Right:
        //    //        playerPositionX = 2.25f;
        //    //        break;
        //    //}
        //}

        //if (playerTransform.position.x != playerPositionX)
        //{
        //    playerTransform.position = new Vector3(playerPositionX, playerTransform.position.y, playerTransform.position.z);
        //}

        //// update player & camera translation
        //playerTransform.position += new Vector3(0.0f, 0.0f, ForwardVelocity);
        //cameraTransform.position = new Vector3(playerPositionX, cameraTransform.position.y, playerTransform.position.z - CameraDistance);

        ////todo: this could be a function of player movement
        //DuctTapeOuterTransform.Rotate(new Vector3(0f, 0f, -TapeRotationalVelocityZ));

        #endregion
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var directionalMovement = context.ReadValue<Vector2>();
            var movementX = directionalMovement.x;

            if (timeSinceLaneChange >= changeLaneDelay)
            {
                if (movementX > 0)
                {
                    changeLaneDelay = 0f;
                    PlayerPosition--;
                }
                else if (movementX < 0)
                {
                    changeLaneDelay = 0f;
                    PlayerPosition++;
                }
            }

            if (PlayerPosition > 21)
            {
                PlayerPosition = 0;
            }
            else if (PlayerPosition < 0)
            {
                PlayerPosition = 21;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crack")
        {
            GameManager.instance.AddPoints(100);
        }
    }
}