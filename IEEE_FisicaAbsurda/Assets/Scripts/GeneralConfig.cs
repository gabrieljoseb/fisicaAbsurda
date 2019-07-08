using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralConfig : MonoBehaviour
{
    public bool menuAtivo; //Será mantido temporariamente, apenas para facilitar no desenvolvimento do jogo.
    [Space(20)]
    [SerializeField] //Torna visivel na interface da Unity a variável privada.
    private GameObject menuPrincipal;
    [SerializeField]
    private GameObject pause;

    private bool primeiroVezMenu; //Mostra se é a primeira vez dele no menu após abrir o jogo.
    static public bool estaPausado; //Variável que registra se o jogo está pausado ou não
    static public bool menuAtivado; //Variável que registra se o jogo está no Menu Inicial ou não


    private void Awake()
    {
        Pause(false); //Desativa o Pause
    }

    private void Start()
    {
        primeiroVezMenu = true;
        MenuInicial(true); //Ativa o Menu

        primeiroVezMenu = true;
        MenuInicial(menuAtivo); //Será mantido temporariamente, apenas para facilitar no desenvolvimento do jogo.
    }

    private void Update()
    {
        if (Player.isDead)//Se o Player está morto.
        {
            //GAME OVER
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && !menuAtivado) //Verifica se o "ESC" OU "P" foi apertado E se o Menu NÃO está desativado
            {
                Pause(!estaPausado); //Ativa/Desativa o Pause
            }
        }
    }

    private void PararOJogo(bool ativo) //Para o jogo caso o parâmentro seja verdadeiro
    {
        if (ativo) //Se ativo = true
        {
            Time.timeScale = 0; //Isso irá fazer o jogo ficar parado
        }
        else
        {
            Time.timeScale = 1; //Isso fará o jogo voltar a se mexer
        }
    }

    public void Pause(bool statusPause) //Pausa o jogo caso o parâmentro seja verdadeiro
    {
        estaPausado = statusPause;
        PararOJogo(statusPause);
        pause.SetActive(statusPause);
    }

    public void MenuInicial(bool statusMenu)
    {
        menuAtivado = statusMenu;

        if ((statusMenu && primeiroVezMenu) || !statusMenu) //Se o menu for ativo pela primeira vez OU o menu for desativado ele irá...
        {
            PararOJogo(statusMenu);
            menuPrincipal.SetActive(statusMenu);
            primeiroVezMenu = false;
        }
        else if (statusMenu && !primeiroVezMenu) //Se ele for ativo sem ser a primeira vez..
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main"); //Reinicia o Jogo
        }
    }
}
