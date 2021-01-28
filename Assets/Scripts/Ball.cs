using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool onGround;
    Rigidbody2D ball;
    float accel, xSpeed, ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        accel = 0.5f;
        xSpeed = 10f;
        ySpeed = 10f;
        onGround = false;

        ball = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D()
    {
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            ball.velocity = new Vector2(ball.velocity.x, ySpeed);
        }

        if(Input.GetKey(KeyCode.A))
        {
            if(ball.velocity.x > -xSpeed)
                ball.velocity -= new Vector2(accel, ball.velocity.y);
        }

        if(Input.GetKey(KeyCode.D))
        {
            while(ball.velocity.x < xSpeed)
                ball.velocity -= new Vector2(accel, ball.velocity.y);
        }
    }
}
