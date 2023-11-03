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
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    public Boolean isAggro;
    private Transform player;
    private float awarenessRadius = 6f;
    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }


    private void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if(dist < awarenessRadius) isAggro = true;
        if (isAggro) ;
    }
}
