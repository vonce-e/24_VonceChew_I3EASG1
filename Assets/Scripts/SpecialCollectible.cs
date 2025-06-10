/*
 * Author : Vonce Chew
 * Date of Creation : 9th June 2025
 * Script Function : Special Collectibles script that handles functions of the special collectibles in the game, such as collecting items and updating points.
 */

using Mono.Cecil.Cil;
using UnityEngine;

public class SpecialCollectible : MonoBehaviour
{
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

        //Destroys collectible after collection
        Destroy(gameObject);
    }
    void Update()
    {
        //Make Special Item spin
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}