using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedrasConfig : MonoBehaviour
{
    public GameObject gradeDaFase; //Armazena a grade q impede a conclusão da fase
    public GameObject Hud_Pedra;


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.tag == "Player")
        {
            gameObject.SetActive(false); //Desativa o sprite da Pedra
            gradeDaFase.SetActive(false);//Desativa a grade da fase
            Hud_Pedra.SetActive(true);
        }
    }
}
