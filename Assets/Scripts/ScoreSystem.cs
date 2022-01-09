using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Triggers triggers;
    public Typer typer;
    public float currentScore = 0;
    public float scoreAdd = 0;

    public Text scoreText;

    public bool money1 = false;
    public bool money2 = false;
    public bool loseMoney = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GiveScore()
    {
        if (money1 == true)
        {
            currentScore += 50;
            scoreText.text = currentScore.ToString();
            triggers.currentParticle = triggers.money1Particle;
        }
        if (money2 == true)
        {
            currentScore += 100;
            scoreText.text = currentScore.ToString();
            triggers.currentParticle = triggers.money2Particle;
        }
        if (loseMoney == true)
        {
            currentScore -= 50;
            scoreText.text = currentScore.ToString();
            triggers.currentParticle = triggers.loseMoneyParticle;
        }
    }
}
