using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawner;
    private float fireRate1 = 2f; //tiro devagar
    private float fireRate2 = 0.01f; //tiro laser
    private float nextFire;

    static public bool isDead = false; //Registra se o Player está morto ou não.


    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) //tiro devagar
        {
            nextFire = Time.time + fireRate1;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
        if (Input.GetButton("Fire2") && Time.time > nextFire) //tiro laser
        {
            nextFire = Time.time + fireRate2;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
    }
}
