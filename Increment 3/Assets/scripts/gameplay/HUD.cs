using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //bounce cout support 
    [SerializeField]
    Text Ltext;
    static Text  LBouncerCounter;
    int Lbounces = 0;

    [SerializeField]
    Text Rtext ;
    static Text RBouncerCounter;
    int Rbounces = 0;

    // Score count cupport
    [SerializeField]
    Text score;
    static Text Stext;
    static float LScore = 0;
    static float RScore = 0;

    //for the text once game starts, as in the video
    const string ScorePrefix = "Hits: ";
    const string ScoreDash = " - ";






    // Start is called before the first frame update
    void Start()
    {
        //as in the video to change the text when the game starts

        LBouncerCounter = Ltext.GetComponent<Text>();
        LBouncerCounter.text = ScorePrefix + Lbounces.ToString();

        RBouncerCounter = Rtext.GetComponent<Text>();
        RBouncerCounter.text = ScorePrefix + Rbounces.ToString();

        Stext = score.GetComponent<Text>();
        Stext.text = LScore.ToString() + ScoreDash + RScore.ToString();

    }

    //functon to add the time the ball hits
    public void AddPoints(int points, ScreenSide DefaultLeft)
    {
        if(DefaultLeft == ScreenSide.Left)
        {
            Lbounces += points;
            LBouncerCounter.text = ScorePrefix + Lbounces.ToString();

        }
        else
        {
            Rbounces += points;
            RBouncerCounter.text = ScorePrefix + Rbounces.ToString();
        }

    }

    //functoin to add the times the ball gets out of the scene
    public void AddToScore(int realPoints, ScreenSide scoreSide)
    {
        if(scoreSide == ScreenSide.Left)
        {
            LScore += realPoints;
        }
        else
        {
            RScore += realPoints;
        }

        Stext.text = LScore.ToString() + ScoreDash + RScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


