/*
 * Author : Vonce Chew
 * Date of Creation : 13th June 2025
 * Script Function : End Game Menu script that handles the end game menu in the game.
 */

using Unity.VisualScripting;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver(); //Calls the GameOver method in GameManager when player enters the trigger area
        }
    }
}
