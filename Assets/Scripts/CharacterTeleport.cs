using UnityEngine;

//Teleports the player to a predefined target position when called.
public class CharacterTeleport : MonoBehaviour
{
private CharacterController controller;
    private Rigidbody rb;

    [Header("Teleport Settings")]
    public Vector3 targetPosition;

    [Tooltip("Assign the camera follow transform (e.g., PlayerCameraRoot)")]
    public Transform cameraRoot;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    //Teleports the character and camera root to the targetPosition.
    public void TeleportToTarget()
    {
        TeleportTo(targetPosition);
    }

    //Teleports the character and camera root to the specified position.
    //Properly handles CharacterController and Rigidbody components.
    //The new world position to teleport to.
    public void TeleportTo(Vector3 newPosition)
    {
        if (controller != null)
        {
            controller.enabled = false;
        }

        if (rb != null)
        {
            //Disable physics during teleport to avoid glitches
            rb.isKinematic = true;
        }

        //Set position
        transform.position = newPosition;

        if (controller != null)
        {
            controller.enabled = true;
        }

        if (rb != null)
        {
            rb.isKinematic = false;
            //Reset velocity to stop any residual motion
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (cameraRoot != null)
        {
            cameraRoot.position = newPosition;
        }
    }
}