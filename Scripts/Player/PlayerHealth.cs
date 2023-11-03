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
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public int maxArmour;
    private int armour;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        Debug.Log(maxHealth);
        CanvasManager.Instance.UpdateHealth(health, maxHealth);
        CanvasManager.Instance.UpdateArmour(armour);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamagePlayer(int damage)
    {
        if (armour > 0)
        {
            if (armour >= damage) armour -= damage;
            else if (armour < damage)
            {
                int remainder = damage - armour;
                armour = 0;
                health -= remainder;
            }
        }
        else
        {
            GetComponent<AudioSource>().Play();
            health -= damage;
        }
        if(health < 0)
        {
            Debug.Log("YOU DIED");
            Scene curScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(curScene.buildIndex); health = maxHealth;
        }
        CanvasManager.Instance.UpdateHealth(health, maxHealth);
        CanvasManager.Instance.UpdateArmour(armour);
    }

    public Boolean GainLife(int amount, GameObject pickup)
    {
        if(health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
            CanvasManager.Instance.UpdateHealth(health, maxHealth);
            return true;
        }
        if (health > maxHealth) health = maxHealth;
        CanvasManager.Instance.UpdateHealth(health, maxHealth);
        return false;
    }

    public Boolean GainArmour(int amount, GameObject pickup)
    {
        if (armour < maxArmour)
        {
            armour += amount;
            Destroy(pickup, 1f);
            CanvasManager.Instance.UpdateArmour(armour);
            return true;
        }
        if (armour > maxArmour) armour = maxArmour;
        CanvasManager.Instance.UpdateArmour(armour);
        return false;
    }
}
