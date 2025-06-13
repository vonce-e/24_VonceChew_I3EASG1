/*
 * Author : Vonce Chew
 * Date of Creation : 10th June 2025
 * Script Function : Medkit script that handles function of the Medkits in the game.
 */

using UnityEngine;
public class Medkit : MonoBehaviour
{
    [SerializeField] AudioClip collected; //Audio clip to play when the item is collected

    public void Interact()
    {
        //Logic for collecting the item
        Debug.Log(gameObject.name + "collected.");
        
        if (GameManager.Instance.health >= 100)
        {
            Debug.Log("Health is already full, cannot collect medkit.");
            return; // Exit if health is already full
        }

        // Increment points in GameManager
        GameManager.Instance.health += 25;

        // Update points display in GameManager
        GameManager.Instance.HealthUpdate();

        AudioSource.PlayClipAtPoint(collected, transform.position); //Play the collected sound at the item's position

        //Destroys collectible after collection
        Destroy(gameObject);
    }

    void Update()
    {
        //Make Medkit spin
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}
