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
