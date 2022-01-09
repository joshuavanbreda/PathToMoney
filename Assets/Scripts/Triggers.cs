using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public Typer typer;
    public WordBank wordBank;
    public ScoreSystem scoreSystem;
    public ParticleSystem money1Particle;
    public ParticleSystem money2Particle;
    public ParticleSystem loseMoneyParticle;

    public GameObject particlePosition;
    public ParticleSystem currentParticle;
    private Quaternion particleRotation;

    private int triggerStaySafe = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentParticle = money1Particle;
        particleRotation = new Quaternion(1, 0, 1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "UniversityTrigger")
        //{
        //    Instantiate(currentParticle, particlePosition.transform.position, Quaternion.identity);
        //    Debug.Log("entered");
        //}

        if (other.tag == "UniversityTrigger")
        {
            Instantiate(money2Particle, particlePosition.transform.position, Quaternion.Euler(new Vector3(-65, 0, 0)));

            scoreSystem.money1 = false;
            scoreSystem.money2 = true;
            scoreSystem.loseMoney = false;

            scoreSystem.GiveScore();
            wordBank.wordListNum = 2;
            wordBank.needWords = true;
            typer.chooseWord = true;

            StartCoroutine(canTypeWait());

        }

        if (other.tag == "SportsTrigger")
        {
            Instantiate(money1Particle, particlePosition.transform.position, Quaternion.identity);

            scoreSystem.money1 = true;
            scoreSystem.money2 = false;
            scoreSystem.loseMoney = false;

            scoreSystem.GiveScore();
            wordBank.wordListNum = 4;
            wordBank.needWords = true;
            typer.chooseWord = true;

            StartCoroutine(canTypeWait());
        }

        if (other.tag == "PartyingTrigger")
        {
            Instantiate(loseMoneyParticle, particlePosition.transform.position, Quaternion.identity);

            scoreSystem.money1 = false;
            scoreSystem.money2 = false;
            scoreSystem.loseMoney = true;

            scoreSystem.GiveScore();
            wordBank.wordListNum = 5;
            wordBank.needWords = true;
            typer.chooseWord = true;

            StartCoroutine(canTypeWait());
        }

        if (other.tag == "StudyingTrigger")
        {
            Instantiate(money1Particle, particlePosition.transform.position, Quaternion.identity);

            scoreSystem.money1 = true;
            scoreSystem.money2 = false;
            scoreSystem.loseMoney = false;

            scoreSystem.GiveScore();
            wordBank.wordListNum = 3;
            wordBank.needWords = true;
            typer.chooseWord = true;

            StartCoroutine(canTypeWait());
        }

        if (other.tag == "GraduationTrigger")
        {
            Instantiate(money2Particle, particlePosition.transform.position, Quaternion.Euler(new Vector3(-65, 0, 0)));

            scoreSystem.money1 = false;
            scoreSystem.money2 = true;
            scoreSystem.loseMoney = false;

            scoreSystem.GiveScore();
        }

        if (other.tag == "BrokeTrigger")
        {
            Instantiate(loseMoneyParticle, particlePosition.transform.position, Quaternion.identity);

            scoreSystem.money1 = false;
            scoreSystem.money2 = false;
            scoreSystem.loseMoney = true;

            scoreSystem.GiveScore();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "BedroomTrigger" && triggerStaySafe < 1)
        {
            typer.chooseWord = true;
            wordBank.wordListNum = 1;
            triggerStaySafe += 1;
        }
    }

    public IEnumerator canTypeWait()
    {
        yield return new WaitForSeconds(3f);
        typer.canType();

        wordBank.option1txt.gameObject.SetActive(true);
        wordBank.option2txt.gameObject.SetActive(true);
        wordBank.chooseOptiontxt.gameObject.SetActive(true);
    }
}
