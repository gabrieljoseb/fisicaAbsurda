using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : RandomSelection
{
    public GameObject spawningLobby, spawningSala1, spawningSala2, spawningSala3; //, spawningSala3, spawningSala4; //Recebem o Objeto que marcará a posição onde o player irá surgir no teletrasporte 

    static GameObject spawningLobby_, spawningSala1_, spawningSala2_, spawningSala3_;
    static Collider2D Player;
    static public int proximaSala = 0;
    static public int salasConcluidas = 0;
    static public int TiroAtual;

    static public int k = -1;

    private void Start()
    {
        spawningLobby_ = spawningLobby;
        spawningSala1_ = spawningSala1;
        spawningSala2_ = spawningSala2;
        spawningSala3_ = spawningSala3;
        TiroAtual = 1;
        proximaSala = 0;
        salasConcluidas = 0;
        k = -1;
    }

    static public void TrocaDeSala(Collider2D Player)//Realiza o teletrasporte para a próxima sala por meio da lista de ordem randômica
    {
        Debug.Log("Antes do K Peoxima sala" + proximaSala);
        if(k == -1)
        {
            k += 1;
        }
        else if(k < 2)
        {
            proximaSala = ordemSalas[k]; //A "ordemSalas" retorna numeros entre 1 e 2.   
            k += 1;
        }else if (k == 2)
        {
            proximaSala = 3;
            k += 1;
        }

        Debug.Log("Salas Concluidas" + salasConcluidas);
        Debug.Log("ProximaSala" + proximaSala);
        switch (proximaSala)
        {
            case 0:
                Debug.Log("Opção 0");
                TiroAtual = 1; //Será o tiro Lento
                Player.transform.position = spawningLobby_.transform.position; //Teleporta para o Lobby
                break;
            case 1:
                Debug.Log("Opção 1");
                TiroAtual = ordemTiros[0];
                Player.transform.position = spawningSala1_.transform.position;
                break;
            case 2:
                Debug.Log("Opção 2");
                TiroAtual = ordemTiros[1];
                Player.transform.position = spawningSala2_.transform.position;
                break;
            case 3:
                Debug.Log("Opção default");
                TiroAtual = ordemTiros[2];
                Player.transform.position = spawningSala3_.transform.position;
                break;
            default:
                Debug.Log("Deu erro na escolha da sala");
                break;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TrocaDeSala(other);
        }
    }
}
