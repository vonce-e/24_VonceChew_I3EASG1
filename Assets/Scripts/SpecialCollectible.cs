/*
 * Author : Vonce Chew
 * Date of Creation : 9th June 2025
 * Script Function : Special Collectibles script that handles functions of the special collectibles in the game, such as collecting items and updating points.
 */

using Mono.Cecil.Cil;
using UnityEngine;

public class SpecialCollectible : MonoBehaviour
{
    [SerializeField] AudioClip collected; //Audio clip to play when the item is collected
    public void Interact()
    {
        //Logic for collecting the item
        Debug.Log(gameObject.name + "collected.");

        // Increment points in GameManager
        GameManager.Instance.points += 40;

        // Update points display in GameManager
        GameManager.Instance.PointsUpdate();

        // Increment special collectibles count
        GameManager.Instance.specialCollectibles += 1;

        //Update the special collectibles UI text
        GameManager.Instance.SpecialCollectiblesUpdate();

        //Check if all special collectibles have been collected 
        if (GameManager.Instance.specialCollectibles == 3)
        {
            GameManager.Instance.allSpecialCollectibleCollected = true; //All special collectibles collected
            Debug.Log("All special collectibles collected!");
        }

        AudioSource.PlayClipAtPoint(collected, transform.position); //Play the collected sound at the item's position

        //Destroys collectible after collection
        Destroy(gameObject);
    }
}