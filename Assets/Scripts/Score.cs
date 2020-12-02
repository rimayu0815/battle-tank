using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    [SerializeField]
    private Text ScoreLabel;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        DisplayScores();
    }

    public void AddScore(int Getpoint)
    {
        score += Getpoint;

        DisplayScores();
    }

    private void DisplayScores()
    {
        ScoreLabel.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
