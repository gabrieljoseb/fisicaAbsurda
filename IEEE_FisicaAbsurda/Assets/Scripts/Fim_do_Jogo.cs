using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fim_do_Jogo : MonoBehaviour
{
    public GameObject Texto;
    public GameObject Credito;
    public GameObject HUD_Pedras;
    public GameObject HUD_Vidas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        Texto.SetActive(true);
        yield return new WaitForSeconds(7f);
        Credito.SetActive(true);
        HUD_Pedras.SetActive(false);
        HUD_Vidas.SetActive(false);
    }
}
