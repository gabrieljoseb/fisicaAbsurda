using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia_Enemy_Fly : Enemy
{
    private bool isMoving = false;

    protected override void Update()
    {
        base.Update();

        float distance = PlayerDistance();
        isMoving = (distance <= attackDistance);

        if (isMoving)
        {
            if ((target.position.x > transform.position.x) && !sprite.flipX)
            {
                Flipar();
            }
            else if((target.position.x < transform.position.x) && sprite.flipX)
            {
                Flipar();
            }
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Mathf.Abs(speed) * Time.deltaTime);
        }
    }

    float PlayerDistance()
    {
        return Vector2.Distance(target.position, transform.position);
    }

    void Flipar()
    {
        sprite.flipX = !sprite.flipX;
    }
}
