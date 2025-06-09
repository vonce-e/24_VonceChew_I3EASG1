/*
 * Author : Vonce Chew
 * Date of Creation : 9th June 2025
 * Script Function : Special Collectibles script that handles functions of the special collectibles in the game, such as collecting items and updating points.
 */

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

        //Destroys collectible after collection
        Destroy(gameObject);
    }
}