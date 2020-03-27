using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health; //Vida do Inimigo
    public float speed; //Velocidade do Inimigo
    public float attackDistanceX;//Distancia x para efetuar o ataque
    public float attackDistanceY;//Distancia Y para efetuar o ataque
    public float attackDistance;//Distancia X e Y para efetuar ataque

    //protected Animator anim; 
    protected bool facingRight = false; //Inverter o sprite
    protected Transform target; // O Alvo
    protected float targetDistanceX; //Distancia X entre Inimigo e o Player
    protected float targetDistanceY; //Distancia Y entre inimigo e o Player
    protected Vector2 targetDistanceLenght; //Adquirir Distancia X e Y entre Inimigo e Player
    protected float targetDistance; //Aplicar Distancia X e Y entre Inimigo e Player
    protected Rigidbody2D rb2d;
    protected SpriteRenderer sprite;

    void Awake()
    {
        //anim = GetComponent<Animator>(); //Pega o animator do inimigo
        rb2d = GetComponent<Rigidbody2D>(); //Pega o RigidBody do inimigo
        target = FindObjectOfType<Player>().transform; //Pega o Transform do Player
        sprite = GetComponent<SpriteRenderer>();
    }
    

    protected virtual void Update()
    {
        targetDistanceX = transform.position.x - target.position.x; //Posição x do inimigo - posição x do player = Distancia
        targetDistanceY = transform.position.y - target.position.y; //Posição y do inimigo - posição y do player
        targetDistanceLenght = transform.position - target.position; //Posiçao x e y do inimigo - posição x e y do player
        targetDistance = targetDistanceLenght.magnitude;//Magnitude é Rom, então float targetDistance usa pra aplicar
    }

    protected void Flip() // função para inverter o sprite
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TiroLento")) //dá dano se o elemento for tipo PlayerBullet
        {
            TookDamage(1.0f);
        }
        if (other.gameObject.CompareTag("TiroLaser")) //dá dano se o elemento for tipo PlayerBullet
        {
            TookDamage(0.1f);
        }
        if (other.gameObject.CompareTag("TiroSenoidal")) //dá dano se o elemento for tipo PlayerBullet
        {
            TookDamage(3.0f);
        }
    }

    public void TookDamage(float damage)
      {
            health -= damage;
            if (health >= 0)
            {
                StartCoroutine(TookdamageCoRoutine()); //Deixa o sprite vermelho quando toma dano.
            }
            else
            {                
                Destroy(gameObject);    
            }

        IEnumerator TookdamageCoRoutine()
        {
            sprite.color = Color.red; //cor do sprite ficará vermelha ao receber o dano.
            yield return new WaitForSeconds(0.1f); //vai esperar 0.1 segundos.
            sprite.color = Color.white; //cor do sprite volta ao normal.
        }
     }
}
