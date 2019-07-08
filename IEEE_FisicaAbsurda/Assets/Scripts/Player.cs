using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawner;
    private float fireRateSlow = 2f; //tiro devagar
    private float fireRateSenoidal = 1.2f; //tiro senoidal
    private float nextFire;

    static public bool isDead = false; //Registra se o Player está morto ou não.

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) //tiro devagar
        {
            nextFire = Time.time + fireRateSlow;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
        if (Input.GetButton("Fire2")) //tiro laser
        {
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
        if (Input.GetButton("Fire3") && Time.time > nextFire) //tiro senoidal
        {
            nextFire = Time.time + fireRateSenoidal;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
    }
}
