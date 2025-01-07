using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float moveSpeed;
    int score = 0;
    public int winScore;

    float xInput, yInput;
    
    public FixedJoystick joystick;    
    public GameObject winText; 
    public Counter script;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        joystick.CanMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //disabling the movement after time ends
        if (script.remainingTime == 0)
        {
            script.remainingTime = 0;
            joystick.CanMove = false;
        }

        if (xInput != 0 || yInput != 0)
        {
            animator.SetFloat("animatorMoving", (Mathf.Abs(xInput) + Mathf.Abs(yInput)) );
        }

        //when joystick released, set animator speed to 0
        if (joystick.Horizontal + joystick.Vertical == 0) {
            animator.SetFloat("animatorMoving", 0);

        }


    }

    public void FixedUpdate()
    {
        //changing the location of the character when moving
        xInput = joystick.Horizontal * moveSpeed;
        yInput = joystick.Vertical * moveSpeed;

        transform.Translate(xInput, yInput,0);

        //for mirroring the character
        if (xInput > 0)
        {
            gameObject.transform.localScale = new Vector3 ((float)0.14, (float)0.14, (float)0.14);
        }
        else if (xInput < 0) 
        {
            gameObject.transform.localScale = new Vector3((float)-0.14, (float)0.14, (float)0.14);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //to check if player is out of time or not
        if (script.remainingTime > 0)
        {
            if (collision.gameObject.tag == "Target")
            {
                score++;
                Destroy(collision.gameObject);
                if (score == winScore)
                {
                    winText.SetActive(true);
                }

            }

        }


    }
}
