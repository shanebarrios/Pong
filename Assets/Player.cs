using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public bool isAI;

    Ball ball;
    float screenHeight;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        screenHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        float input;
        if (isAI)
        {
            float displacementY = ball.transform.position.y - transform.position.y;
            if (Mathf.Abs(displacementY) > 0.5f) {
                input = System.Math.Sign(ball.transform.position.y - transform.position.y);
            }
            else {
                input = 0;
            }
            
        }
        else {
            input = System.Math.Sign(Input.GetAxisRaw("Vertical"));
        }
        
        float halfLength = transform.localScale.y / 2f;

        if ( (transform.position.y > -screenHeight + halfLength || input == 1) 
            && (transform.position.y < screenHeight - halfLength || input == -1) ) {
            transform.Translate(Vector2.up * input * speed * Time.deltaTime);
        }
        
    }

 
}
