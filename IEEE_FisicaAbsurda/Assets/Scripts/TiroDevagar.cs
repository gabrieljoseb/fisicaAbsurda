﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDevagar : MonoBehaviour
{
    public float speed = 2; //velocidade da bala
    public float destroyTime = 7; //tempo para que a bala suma

    void Start()
    {
        Destroy(gameObject, destroyTime); //destruirá o objeto após o tempo de 'destroyTime'
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); //instancia o tiro para a direita
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //se houver colisão com um game object com a tag 
        if (collision.gameObject.tag == nome da tag)
        {
            Destroy(gameObject); //o projetil se auto destruirá
        }
    }*/
}
