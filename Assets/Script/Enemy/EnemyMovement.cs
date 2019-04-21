using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 4;

    public bool moveDown = false;


    private void Update()
    {
        Vector2 tmpPos = transform.position;

        if (moveDown)
        {
            tmpPos.y -= speed * Time.deltaTime;
        }
        else
        {
            tmpPos.y += speed * Time.deltaTime;
        }

        transform.position = tmpPos;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Tags.WALL))
        {
            moveDown = !moveDown;
        }
        else if (collision.collider.CompareTag(Tags.PLAYER))
        {
            STF.uiManager.EndGame();
            STF.uiManager.game = false;
        }

    }

}
