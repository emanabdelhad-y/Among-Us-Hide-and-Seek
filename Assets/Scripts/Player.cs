using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public FixedJoystick joystick;    
    public float moveSpeed;
    public GameObject winText;
    int score = 0;
    public int winScore;
    float xInput, yInput;
    public Counter script;


    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        joystick.CanMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //update timer
    }

    public void FixedUpdate()
    {
        xInput = joystick.Horizontal * moveSpeed;
        yInput = joystick.Vertical * moveSpeed;

        transform.Translate(xInput, yInput,0);

        if (script.remainingTime == 0)
        {
            script.remainingTime = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (script.remainingTime > 0)
        {
            if (collision.gameObject.tag == "Target")
            {
                score++;
                Destroy(collision.gameObject);
                if (score == winScore) //&& remainingTime>=0 
                {
                    winText.SetActive(true);
                }

            }

        }
        else
        {
            //show Game Over Text
            //Show menu (repeat, main menu, store)
            //freeze player
            joystick.CanMove = false;
        }


    }
}
