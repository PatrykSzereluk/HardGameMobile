using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;


    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        Vector2 tmpPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            tmpPos.y += speed *Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            tmpPos.y -= speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            tmpPos.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tmpPos.x += speed * Time.deltaTime;
        }

        Vector3 tmp = new Vector3(tmpPos.x, tmpPos.y, -2);
        transform.position = tmp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag(Tags.ENDGAME))
        {
            STF.uiManager.EndGame();
            STF.uiManager.game = false;
            STF.uiManager.SavePlayerTime();
        }
    }

}
