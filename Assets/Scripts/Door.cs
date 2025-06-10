/*
 * Author : Vonce Chew
 * Date of Creation : 10th June 2025
 * Script Function : Door script that handles door interactions, including opening and closing doors based on player interaction.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Enum to define keycard colors
    public enum KeycardColor
    {
        Red,
        Blue,
        Green
    }

    [Header("Door Settings")]
    [Tooltip("Color of the Door")]

    //The color of the door, which determines which keycard can open it
    public KeycardColor keycardColor;

    //Reference to the door GameObject that will be opened or closed
    [SerializeField] GameObject DoorObject;

    public bool DoorOpen;

    public bool CanInteract;

    //Method called when the player enters the trigger collider of the door
    private void OnTriggerEnter(Collider other)
    {
        //Displays door locked message if the player does not have the correct keycard

        if (other.gameObject.tag == "Player" && keycardColor == KeycardColor.Red && GameManager.Instance.redKeycardCollected == false)
        {
            CanInteract = false;
            GameManager.Instance.doorLockedHeaderMessage.gameObject.SetActive(true); //Activates the door locked header message
            GameManager.Instance.doorLockedMessage.gameObject.SetActive(true); //Activates the door locked message
            GameManager.Instance.doorLockedPanel.gameObject.SetActive(true); //Activates the door locked panel
        }

        if (other.gameObject.tag == "Player" && keycardColor == KeycardColor.Green && GameManager.Instance.greenKeycardCollected == false)
        {
            CanInteract = false;
            GameManager.Instance.doorLockedHeaderMessage.gameObject.SetActive(true); //Activates the door locked header message
            GameManager.Instance.doorLockedMessage.gameObject.SetActive(true); //Activates the door locked message
            GameManager.Instance.doorLockedPanel.gameObject.SetActive(true); //Activates the door locked panel
        }

        if (other.gameObject.tag == "Player" && keycardColor == KeycardColor.Red && GameManager.Instance.redKeycardCollected == false)
        {
            CanInteract = false;
            GameManager.Instance.doorLockedHeaderMessage.gameObject.SetActive(true); //Activates the door locked header message
            GameManager.Instance.doorLockedMessage.gameObject.SetActive(true); //Activates the door locked message
            GameManager.Instance.doorLockedPanel.gameObject.SetActive(true); //Activates the door locked panel
        }

        if (other.gameObject.tag == "Player")
            CanInteract = true;
        other.GetComponent<PlayerInteraction>().SetCurrentDoor(this);
    }

    //Method called when the player exits the trigger collider of the door
    private void OnTriggerExit(Collider other)
    {
        CanInteract = false;
        GameManager.Instance.doorLockedHeaderMessage.gameObject.SetActive(false); //Deactivates the door locked header message
        GameManager.Instance.doorLockedMessage.gameObject.SetActive(false); //Deactivates the door locked message
        GameManager.Instance.doorLockedPanel.gameObject.SetActive(false); //Deactivates the door locked panel

        if (other.gameObject.tag == "Player" && DoorOpen == true)
        {
            CanInteract = true;
            CloseDoor();
            DoorOpen = false;
        }
        other.GetComponent<PlayerInteraction>().SetCurrentDoor(null);
    }

    //GameManager.Instance.doorLockedHeaderMessage.gameObject.SetActive(true); //Activates the door locked header message
    //GameManager.Instance.doorLockedMessage.gameObject.SetActive(true); //Activates the door locked message
    //Method to interact with the door, checking if the player has the correct keycard to open it
    public void InteractDoor()
    {
        if (CanInteract == true)
        {
            if (DoorOpen == false)
            {
                //Checks if the player has the correct keycard to open the door

                if (keycardColor == KeycardColor.Red && GameManager.Instance.redKeycardCollected == true)
                {
                    OpenDoor();
                    DoorOpen = true;
                }

                if (keycardColor == KeycardColor.Blue && GameManager.Instance.blueKeycardCollected == true)
                {
                    OpenDoor();
                    DoorOpen = true;
                }

                if (keycardColor == KeycardColor.Green && GameManager.Instance.greenKeycardCollected == true)
                {
                    OpenDoor();
                    DoorOpen = true;
                }
            }

            else
            {
                CloseDoor();
                DoorOpen = false;
            }
        }
    }

    //Method to open the door, rotating it 90 degrees to the left
    public void OpenDoor()
    {
        Vector3 currentRotation = DoorObject.transform.eulerAngles;
        currentRotation.y -= 90;
        DoorObject.transform.eulerAngles = currentRotation;
    }

    //Method to close the door, rotating it back to its original position
    public void CloseDoor()
    {
        Vector3 currentRoatation = DoorObject.transform.eulerAngles;
        currentRoatation.y += 90;
        DoorObject.transform.eulerAngles = currentRoatation;
    }
}