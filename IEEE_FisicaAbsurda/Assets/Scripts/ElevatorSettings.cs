using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSettings : MonoBehaviour
{
    public GameObject inicio;
    public GameObject fim;
    public float velocidade;
    public bool vertival;
    private bool subindo = true;
    private bool esquerda = true;

    void Update()
    {
        if (vertival)//Se for na Vertical
        {
            SubirDescer(); //Sobe e desce com relação ao parametro Inicio e Fim
        }
        else //Se for na horizontal 
        {
            EsquerdaDireita(); //Vai pra frente e pra trás com relação ao parametro Inicio e Fim
        }
    }

    void SubirDescer()
    {
        if ((transform.position.y > fim.transform.position.y && subindo) || (transform.position.y < inicio.transform.position.y && !subindo))
        {
            subindo = !subindo;
        }

        if (subindo)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);  //ele irá subir
        }
        else
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
    }

    void EsquerdaDireita()
    {
        if ((transform.position.x < fim.transform.position.x && esquerda) || (transform.position.x > inicio.transform.position.x && !esquerda))
        {
            esquerda = !esquerda;
        }

        if (esquerda)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);  //ele irá subir
        }
        else
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
    }
}

    

