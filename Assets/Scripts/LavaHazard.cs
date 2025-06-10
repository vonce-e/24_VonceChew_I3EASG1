/*
 * Author : Vonce Chew
 * Date of Creation : 10th June 2025
 * Script Function : Lava hazard script that handles the lava hazard in the game.
 */

using UnityEngine;
using System.Collections;   

public class LavaHazard : MonoBehaviour
{
    //Amount of damage applied per tick
    public float damagePerTick = 5f;

    //Time interval between each tick of damage (in seconds)
    public float tickInterval = 1f;

    //Tag identifying damageable objects (e.g., "Player")
    public string targetTag = "Player";

    //Currently running damage coroutine
    private Coroutine damageCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(ApplyDamageOverTime());
            GameManager.Instance.warningText.gameObject.SetActive(true); // Show warning text when entering hazard
            GameManager.Instance.warningPanel.SetActive(true); // Show warning panel when entering hazard
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && damageCoroutine != null)
        {
            GameManager.Instance.warningText.gameObject.SetActive(false); // Show warning text when entering hazard
            GameManager.Instance.warningPanel.SetActive(false); // Show warning panel when entering hazard

            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    //Coroutine that repeatedly applies damage to GameManager.Instance.health.
    private IEnumerator ApplyDamageOverTime()
    {
        while (true)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.health -= damagePerTick;
                Debug.Log($"Player took {damagePerTick} damage. Current health: {GameManager.Instance.health}");
                GameManager.Instance.HealthUpdate(); // Update health UI in GameManager
            }

            yield return new WaitForSeconds(tickInterval);
        }
    }
}
