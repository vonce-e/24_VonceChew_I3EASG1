/*
 * Author : Vonce Chew
 * Date of Creation : 9th June 2025
 * Script Function : Keycard script that handles keycard collection and updates the GameManager accordingly.
 */

using Unity.VisualScripting;
using UnityEngine;

public class Keycard : MonoBehaviour

{

    [SerializeField] AudioClip collected; //Audio clip to play when the item is collected

    //Enum to define keycard colors
    public enum Keycardcolor
    {
        Red,
        Blue,
        Green,
        Black
    }
    [Header("Keycard Settings")]

    [Tooltip("The color of the keycard.")]

    public Keycardcolor keycardColor;

    public void Interact()
    {
        //Displays which keycard was collected in the console
        Debug.Log(keycardColor + "Keycard collected: ");

        //Checks if the keycard is red, blue, or green and updates the GameManager accordingly
        if (keycardColor == Keycardcolor.Red)
        {
            GameManager.Instance.redKeycardCollected = true;
            GameManager.Instance.redKeyCardCheckbox.gameObject.SetActive(true); //Activates the red keycard checkbox in the UI
            GameManager.Instance.redKeyCardText.color = Color.green; //Changes the text color of the red keycard to green in the UI
        }

        else if (keycardColor == Keycardcolor.Blue)
        {
            GameManager.Instance.blueKeycardCollected = true;
            GameManager.Instance.blueKeyCardCheckbox.SetActive(true); //Activates the blue keycard checkbox in the UI
            GameManager.Instance.blueKeyCardText.color = Color.green; //Changes the text color of the blue keycard to green in the UI
        }

        else if (keycardColor == Keycardcolor.Green)
        {
            GameManager.Instance.greenKeycardCollected = true;
            GameManager.Instance.greenKeyCardCheckbox.SetActive(true); //Activates the keycard checkbox in the UI
            GameManager.Instance.greenKeyCardText.color = Color.green; //Changes the text color of the green keycard to green in the UI
        }

        else if (keycardColor == Keycardcolor.Black)
        {
            GameManager.Instance.blackKeycardCollected = true;
            GameManager.Instance.blackKeyCardCheckbox.SetActive(true); //Activates the keycard checkbox in the UI
            GameManager.Instance.blackKeyCardText.color = Color.green; //Changes the text color of the green keycard to green in the UI
        }

        // Increment points in GameManager
        GameManager.Instance.points += 30;

        // Update points display in GameManager
        GameManager.Instance.PointsUpdate();

        AudioSource.PlayClipAtPoint(collected, transform.position); //Play the collected sound at the item's position

        //Destroys keycard after collection
        Destroy(gameObject);
    }
    void Update()
    {
        //Make Keycard spin
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}