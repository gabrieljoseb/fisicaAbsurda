using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDePespectivaSala2 : MonoBehaviour
{
    public GameObject mudanca1, mudanca2, teleport, spawning;
    public GameObject player, mainCamera;
    static public bool cameraInvertida;
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            switch (gameObject.transform.name)
            {
                case "Estatua_camera1":
                    mainCamera.transform.Rotate(new Vector3(0, 0, 180)); //Rotaciona a camera em 180 graus (deixa o jogo de cabeça pra baixo)
                    cameraInvertida = true;
                    break;
                case "Estatua_camera2":
                    mainCamera.transform.Rotate(new Vector3(0, 0, -180));
                    cameraInvertida = false;
                    break;
                case "Teleport":
                    if (cameraInvertida)
                    {
                        mainCamera.transform.Rotate(new Vector3(0, 0, -180)); //Deixa a camera da forma norma
                        cameraInvertida = false;
                    }
                    player.transform.position = spawning.transform.position; //Spawna o player pra parte de queda do mapa
                    break;
            }
        }
    }
}
