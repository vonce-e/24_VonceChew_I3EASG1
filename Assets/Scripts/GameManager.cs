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
    public bool redKeycardCollected = false;
    public bool blueKeycardCollected = false;
    public bool greenKeycardCollected = false;
    public int points = 0;
    public int health = 100;

    //Ensures that only one instance of GameManager exists in the scene
    public static GameManager Instance;

    public TMP_Text pointsText; //UI Text to display points

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

    public void PointsUpdate()
    {
        //Updates the points UI text
        pointsText.text = "Points: " + points.ToString();
    }
}
