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
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private EnemyAggro enemyStatus;
    private Transform playerTransform;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        enemyStatus = GetComponent<EnemyAggro>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyStatus.isAggro) agent.SetDestination(playerTransform.position);
        else agent.SetDestination(transform.position);
    }
}
