using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    Ball ball;
    int leftScore = 0;
    int rightScore = 0;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        ball.OnLeftScore += UpdateScoreLeft;
        ball.OnRightScore += UpdateScoreRight;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScoreLeft() {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
    }

    void UpdateScoreRight() {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
    }
}
