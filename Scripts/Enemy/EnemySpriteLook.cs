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

public class EnemySpriteLook : MonoBehaviour
{
    private Transform target;
    public Boolean canLookVert;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(canLookVert) transform.LookAt(target);
        else
        {
            Vector3 moddedTarget = target.position;
            moddedTarget.y = transform.position.y;
            transform.LookAt(moddedTarget);
        }
    }
}
