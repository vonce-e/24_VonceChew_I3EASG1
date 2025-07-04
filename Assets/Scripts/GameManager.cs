/*
 * Author : Vonce Chew
 * Date of Creation : 9th June 2025
 * Script Function : GameManager script that manages game state, including keycard collection, points, and health.
 */

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //General variables

    [SerializeField] PlayerInteraction playerInteraction; //Reference to the PlayerInteraction script
    [SerializeField] CharacterTeleport characterTeleport; //Reference to the CharacterTeleport script
    [SerializeField] AudioClip death; //Audio clip to play when the item is collected

    //Keycard Related Variables
    public bool redKeycardCollected = false;
    public bool blueKeycardCollected = false;
    public bool greenKeycardCollected = false;
    public bool blackKeycardCollected = false;

    public GameObject redKeyCardCheckboxBackground; //Checkbox Background for red keycard
    public GameObject blueKeyCardCheckboxBackground; //Checkbox Background for blue keycard
    public GameObject greenKeyCardCheckboxBackground; //Checkbox Background for green keycard
    public GameObject blackKeyCardCheckboxBackground; //Checkbox Background for black keycard

    public GameObject redKeyCardCheckbox; //Checkbox for red keycard
    public GameObject blueKeyCardCheckbox; //Checkbox for blue keycard
    public GameObject greenKeyCardCheckbox; //Checkbox for green keycard
    public GameObject blackKeyCardCheckbox; //Checkbox for black keycard

    public int points = 0; //Player's points
    public float health = 100; //Player's health
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
    public TMP_Text blackKeyCardText; //UI Text to display black keycard status
    public TMP_Text purpleDoorHintMessage; //UI Text to display hint for purple door

    public TMP_Text doorLockedHeaderMessage; //UI Text to display door locked header message
    public TMP_Text doorLockedMessage; //UI Text to display door locked message
    public GameObject doorLockedPanel; //UI Panel for door locked messages

    public TMP_Text warningText; //UI Text for warning background
    public GameObject warningPanel; //UI Panel for warning messages

    public GameObject endGameMenuBackground; //Background for the end game menu

    public int damageTaken = 0; //Tracks the amount of damage taken by the player

    public TMP_Text congratulatoryMessageText; //UI Text to display congratulatory message
    public TMP_Text pointsStatsText; //UI Text to display points stats
    public TMP_Text livesStatsText; //UI Text to display lives stats
    public TMP_Text damageStatsText; //UI Text to display damage stats
    public TMP_Text specialItemsStatsText; //UI Text to display special items stats
    public GameObject endGameRestartButton; //Button to restart the game at the end

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
            AudioSource.PlayClipAtPoint(death, transform.position); //Play the collected sound at the item's position
            lives -= 1; //Decreases the number of lives by 1
            health = 100; //Resets health to 100
            playerInteraction.ResetPosition(); //Resets the player's position to the start position

            HealthUpdate(); //Updates the health UI
            LivesUpdate(); //Updates the lives UI
            Debug.Log("You have " + lives + " lives left."); //Logs the number of lives left
            characterTeleport.TeleportToTarget(); //Teleports the player to the target position

            if (lives <= 0) //Checks if there are no lives left
            {
                Debug.Log("Game Over!"); //Logs game over message   
                Destroy(GameManager.Instance.gameObject); //Destroys the GameManager object
                SceneManager.LoadScene(0); //Loads the Game Over scene
            }
        }

        //Check if all keycards are collected and display the purple door hint message
        if (redKeycardCollected == true && blueKeycardCollected == true && greenKeycardCollected == true && blackKeycardCollected == true)
        {
            redKeyCardCheckbox.gameObject.SetActive(false); //Deactivates the red keycard checkbox in the UI
            blueKeyCardCheckbox.SetActive(false); //Deactivates the blue keycard checkbox in the UI
            greenKeyCardCheckbox.SetActive(false); //Deactivates the green keycard checkbox in the UI
            blackKeyCardCheckbox.SetActive(false); //Deactivates the black keycard checkbox in the UI

            redKeyCardText.gameObject.SetActive(false); //Deactivates the red keycard text in the UI
            blueKeyCardText.gameObject.SetActive(false); //Deactivates the blue keycard text in the UI
            greenKeyCardText.gameObject.SetActive(false); //Deactivates the green keycard text in the UI
            blackKeyCardText.gameObject.SetActive(false); //Deactivates the black keycard text in the UI

            redKeyCardCheckboxBackground.SetActive(false); //Deactivates the red keycard checkbox background in the UI
            blueKeyCardCheckboxBackground.SetActive(false); //Deactivates the blue keycard checkbox background in the UI    
            greenKeyCardCheckboxBackground.SetActive(false); //Deactivates the green keycard checkbox background in the UI
            blackKeyCardCheckboxBackground.SetActive(false); //Deactivates the black keycard checkbox background in the UI  


            purpleDoorHintMessage.gameObject.SetActive(true); //Activates the purple door hint message in the UI
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

    //Updates the keycard UI elements
    public void GameOver()
    {
        pointsStatsText.text = "Points : " + points.ToString(); //Updates the points stats text
        livesStatsText.text = "Lives left : " + lives.ToString(); //Updates the lives stats text
        damageStatsText.text = "Damage Taken : " + damageTaken.ToString(); //Updates the damage stats text
        specialItemsStatsText.text = "Special Items Collected : " + specialCollectibles.ToString(); //Updates the special items stats text

        endGameMenuBackground.SetActive(true); //Activates the end game menu background
        congratulatoryMessageText.gameObject.SetActive(true); //Activates the congratulatory message text
        pointsStatsText.gameObject.SetActive(true); //Activates the points stats text
        livesStatsText.gameObject.SetActive(true); //Activates the lives stats text
        damageStatsText.gameObject.SetActive(true); //Activates the damage stats text
        specialItemsStatsText.gameObject.SetActive(true); //Activates the special items stats text
        endGameRestartButton.SetActive(true); //Activates the restart button in the end game menu


        Cursor.lockState = CursorLockMode.None; //Unlocks the cursor
        Time.timeScale = 0f; //Pauses the game time
    }

    public void RestartGame()
    {
        Destroy(GameManager.Instance.gameObject); //Destroys the GameManager object
        SceneManager.LoadScene(0); //Loads the Game Over scene
        Cursor.lockState = CursorLockMode.Locked; //Locks the cursor
        Time.timeScale = 1f; //Restores normal time
    }
}
