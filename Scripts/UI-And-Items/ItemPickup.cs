/*
 *
 * ISTA 351 Intro to Game Dev
 * University of Arizona
 * HUD demo sample code file
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool health;
    public bool armour;
    public bool ammo;

    public int amt;

    private Boolean result;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(result) GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (health) result = other.GetComponent<PlayerHealth>().GainLife(amt, this.gameObject);
            if(armour) result = other.GetComponent<PlayerHealth>().GainArmour(amt, this.gameObject);
            if (ammo) result = other.GetComponentInChildren<Weapon>().GainAmmo(amt, this.gameObject);
        }
    }
}
