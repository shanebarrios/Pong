using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class AI : MonoBehaviour
{
    public float speed;
    Ball ball;
    float screenHeight;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        screenHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ballY = ball.transform.position.y;
        float directionY = System.Math.Sign(ballY - transform.position.y);
        float halfLength = transform.localScale.y / 2f;

        if((transform.position.y > -screenHeight + halfLength || directionY == 1)
            && (transform.position.y < screenHeight - halfLength || directionY == -1)) {
            transform.Translate(Vector2.up*directionY * speed * Time.deltaTime);
        }
    }
}
