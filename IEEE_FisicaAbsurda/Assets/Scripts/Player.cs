using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawner;
    private float fireRate = 0.5f;
    private float nextFire;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
    }
}
