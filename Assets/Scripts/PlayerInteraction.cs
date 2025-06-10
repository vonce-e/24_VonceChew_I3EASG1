/*
 * Author : Vonce Chew
 * Date of Creation : 9th June 2025
 * Script Function : PlayerInteraction script that handles player interactions in the game, using Raycasting.
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    //Raycasting variables
    public Transform playerCamera; //Gets location of player camera
    public float interactionDistance = 5f; //Sets the distance for raycast interactions

    //UI elements   
    public TMP_Text interactionText; //Displays text for interaction prompts

    //Variables
    private Collectibles currentCollectible; //Stores the current collectible item
    private Keycard currentKeycard; //Stores the current keycard item
    private SpecialCollectible currentSpecial; //Stores the current special collectible item
    private Door currentDoor; //Stores the current door item
    private Medkit currentMedkit; //Stores the current medkit item   

    Door CurrentDoor; //Stores door variable

    void Update()
    {
        RaycastHit hitInfo;

        //Casts a ray from the camera forward to detect collectibles
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            //Checks if the raycast hit a coin
            if (hitInfo.transform.TryGetComponent(out currentCollectible))
            {
                interactionText.gameObject.SetActive(true); //Activates the interaction text
                interactionText.text = "Press E to collect"; //Sets the interaction text
            }

            else
            {
                currentCollectible = null; //currentCollectible set to null since there is no collectible in sight
            }

            //Checks if the raycast hit a keycard
            if (hitInfo.transform.TryGetComponent(out currentKeycard))
            {
                interactionText.gameObject.SetActive(true); //Activates the interaction text
                interactionText.text = "Press E to collect the keycard"; //Sets the interaction text
            }

            else
            {
                currentKeycard = null; //currentKeycard set to null since there is no collectible in sight
            }

            //Checks if the raycast hit a special collectible
            if (hitInfo.transform.TryGetComponent(out currentSpecial))
            {
                interactionText.gameObject.SetActive(true); //Activates the interaction text
                interactionText.text = "Press E to collect the special item"; //Sets the interaction text
            }

            else
            {
                currentSpecial = null; //currentSpecial set to null since there is no collectible in sight
            }

            //Checks if the raycast hit a door
            if (hitInfo.transform.TryGetComponent(out currentDoor))
            {
                interactionText.gameObject.SetActive(true); //Activates the interaction text
                interactionText.text = "Press E to interact"; //Sets the interaction text
            }

            else
            {
                currentDoor = null; //currentDoor set to null since there is no door in sight
            }

            //Checks if the raycast hit a Medkit
            if (hitInfo.transform.TryGetComponent(out currentMedkit))
            {
                interactionText.gameObject.SetActive(true); //Activates the interaction text
                interactionText.text = "Press E to heal"; //Sets the interaction text
            }

            else
            {
                currentMedkit = null; //currentMedkit set to null since there is no medkit in sight
            }

        }

        else
        {
            interactionText.gameObject.SetActive(false); //Deactivates the interaction text if no raycast hit
            currentCollectible = null; //currentCollectible set to null since there is no collectible in sight
            currentKeycard = null; //currentKeycard set to null since there is no keycard in sight
            currentSpecial = null; //currentSpecial set to null since there is no collectible in sight
        }

    }


    public void OnInteract()
    {
        if (currentCollectible != null)
        {
            currentCollectible.Interact(); //Calls the Collect method on the current Collectible
            interactionText.gameObject.SetActive(false); //Deactivates the interaction text after collection
        }

        if (currentKeycard != null)
        {
            currentKeycard.Interact(); //Calls the Collect method on the current Keycard
            interactionText.gameObject.SetActive(false); //Deactivates the interaction text after collection
        }

        if (currentSpecial != null)
        {
            currentSpecial.Interact(); //Calls the Collect method on the current Special Collectible
            interactionText.gameObject.SetActive(false); //Deactivates the interaction text after collection
        }

        if (CurrentDoor != null) //Checks if the player is interacting with a door
        {
            CurrentDoor.InteractDoor(); //Calls the InteractDoor method on the current Door
        }

        if (currentMedkit != null)
        {
            currentMedkit.Interact(); //Calls the Collect method on the current Medkit
            interactionText.gameObject.SetActive(false); //Deactivates the interaction text after collection
        }
    }

    //Sets the current door that the player is interacting with
    public void SetCurrentDoor(Door door)
    {
        CurrentDoor = door;
    }
}
