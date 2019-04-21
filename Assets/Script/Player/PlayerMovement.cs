using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public Joystick joystick;


    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {

        Vector2 tmpPos = transform.position;

            tmpPos.y += speed *Time.deltaTime * joystick.Vertical;

            tmpPos.x += speed *Time.deltaTime * joystick.Horizontal;
        

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
