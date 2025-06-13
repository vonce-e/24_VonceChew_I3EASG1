/*
 * Author : Vonce Chew
 * Date of Creation : 11th June 2025
 * Script Function : Laser hazard script that handles the electric hazard in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHazard : MonoBehaviour
{
    //The child GameObject to show/hide
    public GameObject laserBeam;

    //Damage to deal per hit
    public float damage = 5f;

    //How long the laser is active
    public float activeDuration = 1f;

    //How long the laser is off
    public float cooldownDuration = 1f;

    //Whether the laser is currently active
    private bool isActive = false;

    private void Start()
    {
        if (laserBeam != null)
            StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            //Activate
            laserBeam.SetActive(true);
            isActive = true;

            yield return new WaitForSeconds(activeDuration);

            //Deactivate
            laserBeam.SetActive(false);
            isActive = false;

            yield return new WaitForSeconds(cooldownDuration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            DealDamage();
        }
    }
    private void DealDamage()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.health -= damage;
            GameManager.Instance.damageTaken += (int)damage; //Increment damage taken by the amount of damage dealt
            Debug.Log("Player hit by laser! Health: " + GameManager.Instance.health);
            GameManager.Instance.HealthUpdate(); //Update health UI in GameManager
        }
    }
}
