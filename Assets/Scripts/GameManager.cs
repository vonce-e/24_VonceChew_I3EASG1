/*
 * Author : Vonce Chew
 * Date of Creation : 9th June 2025
 * Script Function : GameManager script that manages game state, including keycard collection, points, and health.
 */

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //General variables

    //Keycard Related Variables
    public bool redKeycardCollected = false;
    public bool blueKeycardCollected = false;
    public bool greenKeycardCollected = false;

    public GameObject redKeyCardCheckbox; //Checkbox for red keycard
    public GameObject blueKeyCardCheckbox; //Checkbox for blue keycard
    public GameObject greenKeyCardCheckbox; //Checkbox for green keycard

    public int points = 0; //Player's points
    public int health = 100; //Player's health
    public int lives = 3; //Number of lives the player has
    public int specialCollectibles; //Number of special collectibles collected  
    public bool allSpecialCollectibleCollected = false; //Status of special collectible collection

    //Ensures that only one instance of GameManager exists in the scene
    public static GameManager Instance;

    //UI Text elements for displaying game information
    public TMP_Text pointsText; //UI Text to display points

    public TMP_Text healthText; //UI Text to display health

    public TMP_Text livesText; //UI Text to display lives

    public TMP_Text allSpecialCollectiblesText; //UI Text to display special collectibles

    public TMP_Text redKeyCardText; //UI Text to display red keycard status
    public TMP_Text blueKeyCardText; //UI Text to display blue keycard status   
    public TMP_Text greenKeyCardText; //UI Text to display green keycard status

    public TMP_Text doorLockedHeaderMessage; //UI Text to display door locked header message
    public TMP_Text doorLockedMessage; //UI Text to display door locked message
    public GameObject doorLockedPanel; //UI Panel for door locked messages

    private void Awake()
    {
        //Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //Preserves GameManager across scenes
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject); //Ensures only one instance of  GameManager exists
        }
    }

    //Lives and Health Management
    private void Update()
    {
        if (health <= 0) //Checks if health is less than or equal to 0
        {
            lives -= 1; //Decreases the number of lives by 1
            health = 100; //Resets health to 100

            HealthUpdate(); //Updates the health UI
            LivesUpdate(); //Updates the lives UI

            Debug.Log("You have " + lives + " lives left."); //Logs the number of lives left

            if (lives <= 0) //Checks if there are no lives left
            {
                Debug.Log("Game Over!"); //Logs game over message
                //Game over logic
            }
        }
    }

    //Updates the UI elements
    public void HealthUpdate()
    {
        healthText.text = "Health: " + health.ToString(); //Updates the health UI text
    }

    public void LivesUpdate()
    {
        livesText.text = "Lives: " + lives.ToString(); //Updates the lives UI text
    }   

    public void PointsUpdate()
    {
        pointsText.text = "Points: " + points.ToString(); //Updates the points UI text
    }

    public void SpecialCollectiblesUpdate()
    {
        allSpecialCollectiblesText.text = "Special Items : " + specialCollectibles.ToString() + "/3" ; //Updates the special collectibles UI text

        if (allSpecialCollectibleCollected == true) //Checks if all special collectibles have been collected
        {
            allSpecialCollectiblesText.color = Color.green; //Changes the text color to green
        }
    }
}
