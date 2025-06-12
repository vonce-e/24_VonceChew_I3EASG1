/*
 * Author : Vonce Chew
 * Date of Creation : 12th June 2025
 * Script Function : PauseMenu script that handles function of the pause menu in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI; //Reference to the pause menu UI GameObject 
        
    //Method to handle player pause interaction
    public void OnPause()
    {
        Debug.Log("Pause button pressed"); //Logs to console that the pause button was pressed

        if (isPaused == false) //Checks if the game is not paused
        {
            PauseGame(); //Calls the PauseGame method in the PauseMenu script
        }
        else
        {
            ResumeGame(); //Calls the ResumeGame method in the PauseMenu script
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; //Freezes all time-based movement
        isPaused = true;

        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; //Restores normal time
        isPaused = false;

        pauseMenuUI.SetActive(false);
    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
