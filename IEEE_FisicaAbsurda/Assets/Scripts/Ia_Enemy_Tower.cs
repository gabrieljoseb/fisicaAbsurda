using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia_Enemy_Tower : Enemy
{
    public GameObject bulletPrefab;
    public Transform shotSpawner;

    private bool Attack = false;
    private float fireRate = 2f;
    private float nextFire;


    void Start()
    {
        health = 4.0f;
    }

    private void LateUpdate()
    {
        while (Time.time > nextFire && Attack)
        {
            GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
            nextFire = Time.time + fireRate;
        }
    }
    protected override void Update()
    {
        base.Update();
        if (Mathf.Abs(targetDistanceX) <= attackDistanceX)
        {
            Attack = true;
        }

    }
}
