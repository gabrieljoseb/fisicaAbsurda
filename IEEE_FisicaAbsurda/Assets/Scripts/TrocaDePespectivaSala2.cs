using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDePespectivaSala2 : MonoBehaviour
{
    public GameObject mudanca1, mudanca2, teleport, spawning;
    public GameObject player, mainCamera;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            switch (gameObject.transform.name)
            {
                case "Estatua_camera1":
                    mainCamera.transform.Rotate(new Vector3(0, 0, 180)); //Rotaciona a camera em 180 graus (deixa o jogo de cabeça pra baixo)
                    break;
                case "Estatua_camera2":
                    mainCamera.transform.Rotate(new Vector3(0, 0, -180));
                    break;
                case "Teleport":
                    mainCamera.transform.Rotate(new Vector3(0, 0, 0)); //Deixa a camera da forma normal
                    player.transform.position = spawning.transform.position; //Spawna o player pra parte de queda do mapa
                    break;
            }
        }
    }
}
