using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;
	public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject bulletPrefabDevagar;
    public GameObject bulletPrefabSenoidal;
    public GameObject bulletPrefabLaiser;
    public Transform BracoPlayer;
    public Transform shotSpawner;
    public GameObject spawningLobby;
    public GameObject mainCamera;
    private float fireRateSlow = 0.75f; //frquencia do tiro devagar
    private float fireRateSenoidal = 0.5f; //frequencia do tiro senoidal
    private float nextFire;
    private bool facingRight = true;
    private bool jump = false;
    private bool noChao = false;
    private bool walk = false;
    private Animator anim;
	private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Transform GroundCheck;
	private bool invulnerable = false;

    static public float health;
    static public bool isDead; //Registra se o Player está morto ou não.
    private int theScale;
    private GameObject TiroAtual;
   

    void Start()
    {
        health = 3.0f; //inicializa a vida com 3 pontos
		isDead = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
        GroundCheck = gameObject.transform.Find("GroundCheck");
		life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
		if(!isDead)
		{
			noChao = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

			if (Input.GetKey(KeyCode.W) && noChao || Input.GetKey(KeyCode.UpArrow) && noChao)
			{
				jump = true;
				anim.SetTrigger("Jump");
			}
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				walk = true;
				transform.Translate(-Vector2.right * speed * Time.deltaTime);
				if (facingRight)
				{
					Flip();
				}
				anim.SetBool("Walk", true);
			}
			else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				walk = true;
				transform.Translate(Vector2.right * speed * Time.deltaTime);
				if (!facingRight)
				{
					Flip();
				}
				anim.SetBool("Walk", true);
			}
			else
			{
				anim.SetBool("Walk", false);
				walk = false;
			}

			switch (RoomChange.TiroAtual) //Verifica se foi alterado o Tiro Atual
			{
				case 1:
					TiroAtual = bulletPrefabDevagar; //Tiro Lento
					break;
				case 2:
					TiroAtual = bulletPrefabSenoidal; //Tiro Senoidal 
					break;
				case 3:
					TiroAtual = bulletPrefabLaiser; //Tiro Laser
					break;
				default:
					TiroAtual = bulletPrefabSenoidal;
					Debug.Log("Deu erro na atibuição do tiro, Script do Player");
					break;
			}

			if (Input.GetButton("Fire1") && Time.time > nextFire) //tiro devagar
			{
				if(TiroAtual != bulletPrefabLaiser)
				{
					nextFire = Time.time + fireRateSlow;
				}
				GameObject Tiro = Instantiate(TiroAtual, shotSpawner.position, BracoPlayer.rotation);
			}
			
			if (health < 3.0f)
            {
                life3.SetActive(false);
            }
			if (health < 2.0f)
            {
                life2.SetActive(false);
            }
		}
	}

    private void LateUpdate()
    {
        MousePosition();
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpforce));
            jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - BracoPlayer.position.x, mousePos.y - BracoPlayer.position.y);
        BracoPlayer.transform.right = direction;

        if (mousePos.x < BracoPlayer.position.x -0.8f && facingRight && !walk)
        {
            Flip();
            BracoPlayer.transform.right = -direction;
        }
        else if(mousePos.x > BracoPlayer.position.x +0.8f && !facingRight && !walk)
        {
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		if (!invulnerable) 
        {
			if ((collision.gameObject.CompareTag("Enemy")) || (collision.gameObject.CompareTag("EnemyBullet")))
			{
				TookDamage(1.0f);
				invulnerable = true;
				Invoke("resetInvulnerability", 1);
			}
			if (collision.gameObject.CompareTag("Trap"))
			{
				TookDamage(3.0f);
			}
		}
        if(collision.transform.tag == "PlataformaMovel")
        {
            transform.parent = collision.transform; //Torna o Player filho da plataforma móvel, fazendo ele seguir a posição da plataforma
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy")) || (collision.gameObject.CompareTag("EnemyBullet")))
        {
            TookDamage(1.0f);
            invulnerable = true;
            Invoke("resetInvulnerability", 1);
        }
    }
    
    public void respawning()
    {
        if (isDead)
        {
            if (mainCamera.transform.rotation.z != 0)
            {
                mainCamera.transform.Rotate(new Vector3(0, 0, -180)); //Desvira a camera caso esteja ao contrário
            }
            health = 3.0f;
            life1.SetActive(true); //apaga o primeiro coração de vida
            life2.SetActive(true);
            life3.SetActive(true);
            isDead = false;
            anim.SetBool("isDead", isDead); //Para a Animação de morte
            RoomChange.k -= 1;
            gameObject.transform.position = spawningLobby.transform.position;
        }
    }

    void resetInvulnerability()
	{
		invulnerable = false;
	}
	
	void TookDamage(float damage)
    {
        health -= damage; //vida = vida - dano
        if (health <= 0)
        {
            isDead = true;
            life1.SetActive(false); //apaga o primeiro coração de vida
			life2.SetActive(false);
			life3.SetActive(false);
            anim.SetBool("isDead", isDead); //Inicia a Animação de morte
        }
        else
		{
			StartCoroutine(TookdamageCoRoutine());
		}
    }

	IEnumerator TookdamageCoRoutine()
    {
		sprite.color = Color.red; //cor do sprite ficará vermelha ao receber o dano
		yield return new WaitForSeconds(0.1f); //vai esperar 0.1 segundos.
		sprite.color = Color.white; //cor do sprite volta ao normal.
    }
	
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlataformaMovel")
        {
            transform.parent = null; //O Player para de ser filho da plataforma móvel, fazendo com que ele volte a se movimentar normalmente.
        }
    }
}