using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fim_do_Jogo : MonoBehaviour
{
    public GameObject Texto;
    public GameObject Credito;
    public GameObject HUD;
    

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
        HUD.SetActive(false);
        yield return new WaitForSeconds(5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main"); //Reinicia o Jogo
    }
}
