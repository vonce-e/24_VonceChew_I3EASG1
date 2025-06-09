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

    //Variables to store current collectible items
    private Collectibles currentCollectible; //Stores the current collectible item
    private Keycard currentKeycard; //Stores the current keycard item
    private SpecialCollectible currentSpecial; //Stores the current special collectible item

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
                interactionText.text = "Press E to collect"; //Sets the interaction text
            }

            else
            {
                currentKeycard = null; //currentKeycard set to null since there is no collectible in sight
            }

            //Checks if the raycast hit a special collectible
            if (hitInfo.transform.TryGetComponent(out currentSpecial))
            {
                interactionText.gameObject.SetActive(true); //Activates the interaction text
                interactionText.text = "Press E to collect"; //Sets the interaction text
            }

            else
            {
                currentSpecial = null; //currentSpecial set to null since there is no collectible in sight
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
    }   
}
