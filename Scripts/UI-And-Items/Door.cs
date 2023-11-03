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

public class Door : MonoBehaviour
{
    public Animator doorAnime;
    public GameObject areaSpawn;
    private int playableTimes = 1;
    private int timesPlayed = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doorAnime.SetTrigger("OpenDoor");
            areaSpawn.SetActive(true);
            if(timesPlayed < playableTimes) GetComponent<AudioSource>().Play();
            timesPlayed++;
        }
    }

}
