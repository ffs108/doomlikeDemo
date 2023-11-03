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

public class EnemyAlignToPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 targetPos;
    private Vector3 targetDir;

    private float angle;
    public int lastIndex;

    private SpriteRenderer spriteRenderer;
    //public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        targetDir = targetPos - transform.position;
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);
        //Debug.Log(angle);
        lastIndex = GetIndex(angle);
        //spriteRenderer.sprite = sprites[lastIndex];
    }
    private int GetIndex(float angle)
    {
        if (angle >= -45f && angle <= 45f) return 0;
        if (angle > 45f && angle <= 135f) return 1;
        if (angle > 135f || angle <= -135f) return 2;
        if (angle > -135f && angle < -45f) return 3;
        return lastIndex;
    }
}
