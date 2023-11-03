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

public class Weapon : MonoBehaviour
{
    private BoxCollider trigger;
    public EnemyManager enemyManager;
    public Animator gunAnime;

    public float fireRate;
    private float coolDown;
    private int maxAmmo = 50;
    public int ammo;
    public float fullDamage = 1f;
    public float outOfRangeDamage = 0.25f;
    public float hRange = 15f;
    public float vRange = 15f;

    public LayerMask rayLayerMask;
    public LayerMask enemyLayerMask;

    public float shotRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
        trigger.size = new Vector3(1,vRange, hRange);
        trigger.center = new Vector3(0, 0, hRange * 0.5f);
        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > coolDown && ammo > 0) Fire();
    }

    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, shotRadius, enemyLayerMask);

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        foreach(Collider collider in enemyColliders)
        {
            collider.GetComponent<EnemyAggro>().isAggro = true;
        }

        foreach(Enemy enemy in enemyManager.enemiesInTrigger)
        {
            RaycastHit hit;
            Vector3 dir = enemy.transform.position - transform.position;
            if(Physics.Raycast(transform.position, dir, out hit, hRange * 1.15f, rayLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);
                    if(dist > hRange * 0.5f) enemy.TakeDamage(outOfRangeDamage);
                    else enemy.TakeDamage(fullDamage);
                }
            }
        }
        coolDown = Time.time + fireRate;
        ammo--;
        CanvasManager.Instance.UpdateAmmo(ammo);
        gunAnime.SetTrigger("shoot");
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null) enemyManager.AddEnemy(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null) enemyManager.RemoveEnemy(enemy);
    }

    public Boolean GainAmmo(int amount, GameObject pickup)
    {
        if(ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
            CanvasManager.Instance.UpdateAmmo(ammo);
            return true;
        }
        if(ammo > maxAmmo) ammo = maxAmmo;
        CanvasManager.Instance.UpdateAmmo(ammo);
        return false;
    }
}
