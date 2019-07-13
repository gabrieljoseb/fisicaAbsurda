/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Transform shotSpawner;
    // script para a arma seguir o cursor do mouse
    void Update()
    {
        mousePosition();
    }

    void mousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.right = direction;

        if(mousePos.x < transform.position.x)
        {
            transform.right = -direction;
        }
    }                       
}*/
