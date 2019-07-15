using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public GameObject bulletPrefabDevagar;
    public GameObject bulletPrefabSenoidal;
    public GameObject bulletPrefabLaiser;
    public Transform BracoPlayer;
    public Transform shotSpawner;
    private float fireRateSlow = 0.75f; //frquencia do tiro devagar
    private float fireRateSenoidal = 0.5f; //frequencia do tiro senoidal
    private float fireRateEspalhado = 1.3f; //frequencia tiro espalhado
    private float nextFire;
    private bool facingRight = true;
    private bool jump = false;
    private bool noChao = false;
    private bool walk = false;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform GroundCheck;

    static public bool isDead = false; //Registra se o Player está morto ou não.
    private int theScale;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        GroundCheck = gameObject.transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKey(KeyCode.W) && noChao)
        {
            jump = true;
            anim.SetTrigger("Jump");
        }
        if (Input.GetKey(KeyCode.A))
        {
            walk = true;
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            if (facingRight)
            {
                Flip();
            }
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.D))
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

        if (Input.GetButton("Fire1") && Time.time > nextFire) //tiro devagar
        {
            nextFire = Time.time + fireRateSlow;
            GameObject Tiro = Instantiate(bulletPrefabDevagar, shotSpawner.position, BracoPlayer.rotation);
        }
        if (Input.GetButton("Fire2")) //tiro laser
        {
            GameObject Tiro = Instantiate(bulletPrefabDevagar, shotSpawner.position, BracoPlayer.rotation);
        }
        if (Input.GetButton("Fire3") && Time.time > nextFire) //tiro senoidal
        {
            nextFire = Time.time + fireRateSenoidal;
            GameObject Tiro = Instantiate(bulletPrefabDevagar, shotSpawner.position, shotSpawner.rotation);
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
        /*Vector2 direction1 = new Vector2(mousePos.x - BracoPlayer.position.x, mousePos.y - shotSpawner1.position.y);
        Vector2 direction2 = new Vector2(mousePos.x - BracoPlayer.position.x, mousePos.y - shotSpawner2.position.y);
        Vector2 direction3 = new Vector2(mousePos.x - BracoPlayer.position.x, mousePos.y - shotSpawner3.position.y);
        Vector2 direction4 = new Vector2(mousePos.x - BracoPlayer.position.x, mousePos.y - shotSpawner4.position.y);*/
        BracoPlayer.transform.right = direction;
        /*shotSpawner1.transform.right = direction1;
        shotSpawner2.transform.right = direction2;
        shotSpawner3.transform.right = direction3;
        shotSpawner4.transform.right = direction4;*/
        if (mousePos.x < BracoPlayer.position.x -0.1f && facingRight && !walk)
        {
            Flip();
            BracoPlayer.transform.right = -direction;
            /*shotSpawner1.transform.right = -direction1;
            shotSpawner2.transform.right = -direction2;
            shotSpawner3.transform.right = -direction3;
            shotSpawner4.transform.right = -direction4;*/
        }
        else if(mousePos.x > BracoPlayer.position.x +0.1f && !facingRight && !walk)
        {
            Flip();
        }
        /*else if(mousePos.x == BracoPlayer.position.x && !walk)
        {
            
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "PlataformaMovel")
        {
            transform.parent = collision.transform; //Torna o Player filho da plataforma móvel, fazendo ele seguir a posição da plataforma.
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "PlataformaMovel")
        {
            transform.parent = null; //O Player para de ser filho da plataforma móvel, fazendo com que ele volte a se movimentar normalmente.
        }
    }
}