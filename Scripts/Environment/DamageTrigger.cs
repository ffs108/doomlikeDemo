/*
 *
 * ISTA 351 Intro to Game Dev
 * University of Arizona
 * HUD demo sample code file
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private bool damagingPlayer;
    private PlayerHealth playerHealth;

    public int dmgAmt;
    public float timeBetweenDmg = 1.5f;

    private float damageCounter;

    // Start is called before the first frame update
    void Start()
    {
        damageCounter = timeBetweenDmg;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damagingPlayer)
        {
            if (damageCounter >= timeBetweenDmg)
            {
                playerHealth.DamagePlayer(dmgAmt);
                damageCounter = 0f;
            }
            damageCounter += Time.deltaTime;
        }
        else damageCounter = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageCounter = timeBetweenDmg;
            damagingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) damagingPlayer = false;
    }
}
