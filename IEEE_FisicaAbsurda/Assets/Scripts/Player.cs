using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public GameObject bulletPrefab;
    public Transform shotSpawner;
    public Transform shotSpawner1;
    public Transform shotSpawner2;
    public Transform shotSpawner3;
    public Transform shotSpawner4;
    private float fireRateSlow = 2f; //tiro devagar
    private float fireRateSenoidal = 1f; //tiro senoidal
    private float fireRateEspalhado = 1.3f; //tiro espalhado
    private float nextFire;
    private bool facingRight = true;
    private bool jump = false;
    private bool noChao = false;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform GroundCheck;

    static public bool isDead = false; //Registra se o Player está morto ou não.

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
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            if (facingRight)
            {
                Flip();
            }
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (!facingRight)
            {
                Flip();
            }
            anim.SetBool("Walk", true);
        }
        else anim.SetBool("Walk", false);


        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) //tiro devagar
        {
            nextFire = Time.time + fireRateSlow;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
            if (!facingRight)
            {
                Tiro.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
            }
        }
        if (Input.GetButton("Fire2")) //tiro laser
        {
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
            if (!facingRight)
            {
                Tiro.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
            }
        }
        if (Input.GetButton("Fire3") && Time.time > nextFire) //tiro senoidal
        {
            nextFire = Time.time + fireRateSenoidal;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
            if (!facingRight)
            {
                Tiro.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
            }
        }
        if (Input.GetButton("Fire4") && Time.time > nextFire) //tiro espalhado
        {
            nextFire = Time.time + fireRateEspalhado;
            GameObject Tiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
            GameObject Tiro1 = Instantiate(bulletPrefab, shotSpawner1.position, shotSpawner1.rotation);
            GameObject Tiro2 = Instantiate(bulletPrefab, shotSpawner2.position, shotSpawner2.rotation);
            GameObject Tiro3 = Instantiate(bulletPrefab, shotSpawner3.position, shotSpawner3.rotation);
            GameObject Tiro4 = Instantiate(bulletPrefab, shotSpawner4.position, shotSpawner4.rotation);

            if (!facingRight)
            {
                Tiro.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
                Tiro1.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
                Tiro2.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
                Tiro3.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
                Tiro4.transform.eulerAngles = new Vector3(0, -180, 0); //rotaciona 180graus para o tiro para o lado esquerdo
            }
        }
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
}
