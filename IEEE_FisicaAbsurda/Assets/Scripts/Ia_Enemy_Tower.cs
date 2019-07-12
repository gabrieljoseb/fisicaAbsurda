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
        health = 5.0f;
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
        base.Update(); //Chama o script pai    

        // ********Animações*********

        if (facingRight && transform.position.x > target.position.x) //Robô olhar pra esquerda quando detectar player
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = false;
        }
        else
        if (!facingRight && transform.position.x < target.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            facingRight = true;
        }

        if (Mathf.Abs(targetDistanceX) <= attackDistanceX)
        {
            Attack = true; //ativa a animação de ataque
        }

    }

    public void ResetAttack() //O que ocorre após a explosão do Robo01, essa função é chamada pelo Animation>> Ignition
    {
        Destroy(gameObject);
    }
}
