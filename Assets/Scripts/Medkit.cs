/*
 * Author : Vonce Chew
 * Date of Creation : 10th June 2025
 * Script Function : Medkit script that handles function of the Medkits in the game.
 */

using UnityEngine;
public class Medkit : MonoBehaviour
{
    public void Interact()
    {
        //Logic for collecting the item
        Debug.Log(gameObject.name + "collected.");

        // Increment points in GameManager
        GameManager.Instance.health += 25;

        // Update points display in GameManager
        GameManager.Instance.HealthUpdate();

        //Destroys collectible after collection
        Destroy(gameObject);
    }

    void Update()
    {
        //Make Medkit spin
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}
