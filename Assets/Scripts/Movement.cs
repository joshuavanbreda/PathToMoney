using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Typer typer;

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;

    public bool showButtons;

    public GameObject universityCeiling;
    public GameObject studyingCeiling;
    public GameObject graduationCeiling;
    public GameObject sportsCeiling;
    public GameObject partyingCeiling;
    public GameObject brokeCeiling;

    public float t;

    void Start()
    {
        //transform.position = point1.position;

        //Vector3 a = transform.position;

    }

    void FixedUpdate()
    {
        if (typer.posCounter == 1)
        {
            transform.position = point1.position;
        }

        if (typer.posCounter == 2)
        {
            //universityCeiling.SetActive(false);
            sportsCeiling.SetActive(false);
            Vector3 a = transform.position;
            Vector3 b = point2.position;
            transform.position = Vector3.Lerp(a, b, t);
            if (showButtons == true)
            {
                StartCoroutine(buttonWaitPoint2());
            }
        }

        if (typer.posCounter == 3)
        {
            //studyingCeiling.SetActive(false);
            partyingCeiling.SetActive(false);

            Vector3 a = transform.position;
            Vector3 b = point3.position;
            transform.position = Vector3.Lerp(a, b, t);
            if (showButtons == true)
            {
                StartCoroutine(buttonWaitPoint3());
            }
        }

        if (typer.posCounter == 4)
        {
            //graduationCeiling.SetActive(false);
            brokeCeiling.SetActive(false);

            Vector3 a = transform.position;
            Vector3 b = point4.position;
            transform.position = Vector3.Lerp(a, b, t);
        }
    }

    public IEnumerator buttonWaitPoint2()
    {
        showButtons = false;
        yield return new WaitForSeconds(2f);
        //University
        //buttonChoices.studyingBtn.SetActive(true);
        //buttonChoices.partyingBtn.SetActive(true);
        //buttonChoices.partyingBtn.transform.position = new Vector3(buttonChoices.partyingBtn.transform.position.x + 177, buttonChoices.partyingBtn.transform.position.y, buttonChoices.partyingBtn.transform.position.z);

        //Sports
        //buttonChoices.partyingBtn2.SetActive(true);
        //buttonChoices.trainingBtn.SetActive(true);
    }

    public IEnumerator buttonWaitPoint3()
    {
        showButtons = false;
        yield return new WaitForSeconds(2f);
        //Studying
        //buttonChoices.graduationBtn.SetActive(true);
        //buttonChoices.brokeBtn.SetActive(true);

        //Partying
        //buttonChoices.brokeBtn2.SetActive(true);
    }
}
