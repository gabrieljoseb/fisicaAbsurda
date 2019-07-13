using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Transform shotSpawner;
    public Transform shotSpawner1;
    public Transform shotSpawner2;
    public Transform shotSpawner3;
    public Transform shotSpawner4;

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
        Vector2 direction1 = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        Vector2 direction2 = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        Vector2 direction3 = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        Vector2 direction4 = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.right = direction;
        transform.right = direction1;
        transform.right = direction2;
        transform.right = direction3;
        transform.right = direction4;

        if (mousePos.x < transform.position.x)
        {
            transform.right = -direction;
            transform.right = -direction1;
            transform.right = -direction2;
            transform.right = -direction3;
            transform.right = -direction4;
        }
    }                       
}
