using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed;
    public float speedMultiplier;
    public float resetDelay;
    public Vector2 lowerUpperSpawn;
    public event System.Action OnLeftScore;
    public event System.Action OnRightScore;

    float screenHalfWidth;
    float speed;
    Rigidbody2D rb;
    int startDirection;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        startDirection = 1;
        rb = GetComponent<Rigidbody2D>();
        StartBall();
    }
    void StartBall() {
        speed = startSpeed;
        gameObject.SetActive(true);
        rb.velocity = Vector2.right * startSpeed * startDirection;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float ballHalfWidth = transform.localScale.x / 2f;
      
        if (transform.position.x < -screenHalfWidth - ballHalfWidth) {
            if (OnLeftScore != null) {
                OnLeftScore();
            }
            ResetBall();
        }
        else if (transform.position.x > screenHalfWidth + ballHalfWidth) {
            if (OnRightScore != null) {
                OnRightScore();
            }
            ResetBall();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player Paddle" || other.gameObject.name == "AI Paddle")
        {
            speed = startSpeed * speedMultiplier;
            float relativeY = rb.position.y - other.transform.position.y;
            int direction = (other.gameObject.name == "Player Paddle") ? -1 : 1;
            float ratio = relativeY / (other.transform.localScale.y / 2f);
            rb.velocity = new Vector2(direction, ratio).normalized * speed;

        }
        else if (other.gameObject.name == "Upper Bound") {
            rb.velocity = Vector2.Reflect(rb.velocity, Vector2.down);
        }
        else if (other.gameObject.name == "Lower Bound") {
            rb.velocity = Vector2.Reflect(rb.velocity, Vector2.up);
        }
    }

    void ResetBall() {
        gameObject.SetActive(false);
        startDirection = -startDirection;
        float randomStart = Random.Range(lowerUpperSpawn.x, lowerUpperSpawn.y);
        transform.position = new Vector2(0, randomStart);
        Invoke("StartBall", resetDelay);
    }
}
