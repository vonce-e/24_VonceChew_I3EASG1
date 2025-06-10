/*
 * Author : Vonce Chew
 * Date of Creation : 11th June 2025
 * Script Function : Electric hazard script that handles the electric hazard in the game.
 */

using UnityEngine;

public class ElecricHazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.lives -= 1; // Decrease player lives by 1

            GameManager.Instance.health = 100; // Reset player health to 100

            GameManager.Instance.HealthUpdate(); // Update the health UI
            GameManager.Instance.LivesUpdate(); // Update the lives UI

            //Logic to move player back to spawnpoint and display you've died message.
        }
    }
}