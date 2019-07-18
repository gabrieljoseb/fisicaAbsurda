using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDePespectivaSala2 : MonoBehaviour
{
    public GameObject spawning;
    public GameObject player;
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            player.transform.position = spawning.transform.position; //Spawna o player pra parte de queda do mapa
        }
    }
}
