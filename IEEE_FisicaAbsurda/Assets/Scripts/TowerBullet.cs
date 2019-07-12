using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public float speed;
    public int damage = 1; //dano da bala
    public float destroyTime = 1f; //tempo para que a bala suma

    Rigidbody2D rb;
    private Transform player;
    private Vector2 target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(target.x, target.y);
    }

    void Update()
    {
        Destroy(gameObject, destroyTime); //destruirá o objeto após o tempo de 'destroyTime'
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //se houver colisão com um game object com a tag "player" ou "Obj"
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Obj")
        {
            Destroy(gameObject); //o projetil irá se auto destruir
        }
    }
}
