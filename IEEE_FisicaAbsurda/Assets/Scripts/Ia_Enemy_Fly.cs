using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia_Enemy_Fly : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Patrulha();
    }

    public void Patrulha()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (facingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            facingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
    }
}
