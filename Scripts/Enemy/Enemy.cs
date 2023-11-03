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

public class Enemy : MonoBehaviour
{

    private float health = 2;
    public EnemyManager enemyManager;
    public GameObject weoponHitEffect;

    private Animator spriteAnime;
    private EnemyAlignToPlayer angleToPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteAnime = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<EnemyAlignToPlayer>();
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteAnime.SetFloat("SpriteRotation", angleToPlayer.lastIndex);
        if (health <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float dmg)
    {
        Instantiate(weoponHitEffect, transform.position, Quaternion.identity);
        health -= dmg;
    }
}
