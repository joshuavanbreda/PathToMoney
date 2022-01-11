using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public WordBank wordBank;
    public Typer typer;

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public Transform point6;
    public Transform point7;
    public Transform point8;
    public Transform point9;

    public bool showButtons;

    public GameObject universityCeiling;
    public GameObject studyingCeiling;
    public GameObject graduationCeiling;
    public GameObject sportsCeiling;
    public GameObject partyingCeiling;
    public GameObject brokeCeiling;
    public GameObject trainingCeiling;
    public GameObject recruitmentCeiling;

    public GameObject room1Anim;
    public GameObject room2Anim;
    public GameObject room3Anim;
    public GameObject room4Anim;
    public GameObject room5Anim;
    public GameObject room7Anim;
    public GameObject room8Anim;

    private GameObject tempAnim;

    public GameObject cube1;
    public GameObject cube2;


    public bool canMove = false;
    public int lastPoint;

    public bool isMoving;

    public bool needSpawn = true;

    public Vector3 a;

    public float t;

    void Start()
    {
        //transform.position = point1.position;

        //Vector3 a = transform.position;

    }

    void FixedUpdate()
    {
        Vector3 c = cube1.transform.position;
        Vector3 d = cube2.transform.position;
        cube1.transform.position = Vector3.MoveTowards(c, d, t);
        //if (wordBank.workingWords == wordBank.words1)
        //{
        //    if (wordBank.isFirstWord) ;
        //}

        #region posCounter if Statements
        if (typer.posCounter == 1)
        {
            if (needSpawn == true)
            {
                tempAnim = Instantiate(room1Anim, point1.transform.position, Quaternion.identity);

                needSpawn = false;
            }
            
            transform.position = point1.localPosition;
            //transform.position = Vector3.Lerp(point1.position, point2.position, t);
            lastPoint = 1;
        }

        if (typer.posCounter == 2)
        {
            if (canMove == true && wordBank.isFirstWord && lastPoint == 1)
            {
                if (needSpawn == true)
                {
                    Destroy(tempAnim);
                    tempAnim = Instantiate(room2Anim, point2.transform.position, Quaternion.identity);
                    //Destroy(room1Anim);

                    needSpawn = false;
                }
                universityCeiling.SetActive(false);
                Vector3 a = transform.position;
                Vector3 b = point2.position;
                transform.position = Vector3.MoveTowards(a, b, t);
                if (Vector3.Distance(transform.position, b) < 0.5f)
                {
                    canMove = false;
                    lastPoint = 2;
                    Debug.Log("dying inside");
                }
                
            }
            if (canMove == true && wordBank.isSecondWord && lastPoint == 1)
            {
                if (needSpawn == true)
                {
                    Destroy(tempAnim);
                    tempAnim = Instantiate(room3Anim, point3.transform.position, Quaternion.identity);
                    //Destroy(room1Anim);

                    needSpawn = false;
                }
                
                Debug.Log("Hi am i running?");
                sportsCeiling.SetActive(false);
                Vector3 a = transform.position;
                Vector3 b = point3.position;
                transform.position = Vector3.MoveTowards(a, b, t);
                if (Vector3.Distance(transform.position, b) < 0.5f)
                {
                    canMove = false;
                    lastPoint = 3;
                }
                
            }
            //universityCeiling.SetActive(false);

            //if (showButtons == true)
            //{
            //    StartCoroutine(buttonWaitPoint2());
            //}
        }

        if (typer.posCounter == 3)
        {
            if (lastPoint == 2)
            {
                if (canMove == true && wordBank.isFirstWord)
                {
                    if (needSpawn == true)
                    {
                        Destroy(tempAnim);
                        tempAnim = Instantiate(room4Anim, point4.transform.position, Quaternion.identity);
                        //Destroy(room2Anim);

                        needSpawn = false;
                    }
                    
                    studyingCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point4.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 4;
                    }
                    
                }
                if (canMove == true && wordBank.isSecondWord)
                {
                    if (needSpawn == true)
                    {
                        Destroy(tempAnim);
                        tempAnim = Instantiate(room5Anim, point5.transform.position, Quaternion.identity);
                        //Destroy(room2Anim);

                        needSpawn = false;
                    }
                    
                    partyingCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point5.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 5;
                    }
                    
                }
            }

            if (lastPoint == 3)
            {
                if (canMove == true && wordBank.isFirstWord)
                {
                    if (needSpawn == true)
                    {
                        Destroy(tempAnim);
                        tempAnim = Instantiate(room5Anim, point5.transform.position, Quaternion.identity);
                        //Destroy(room3Anim);

                        needSpawn = false;
                    }
                    
                    partyingCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point5.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 5;
                    }
                    
                }
                if (canMove == true && wordBank.isSecondWord)
                {

                    trainingCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point6.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 6;
                    }
                    
                }
            }
        }

        if (typer.posCounter == 4)
        {
            if (lastPoint == 4)
            {
                Debug.Log("Broke Movement las Point4");
                if (canMove == true && wordBank.isFirstWord)
                {
                    if (needSpawn == true)
                    {
                        Destroy(tempAnim);
                        tempAnim = Instantiate(room7Anim, point7.transform.position, Quaternion.identity);
                        //Destroy(room4Anim);

                        needSpawn = false;
                    }
                    
                    graduationCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point7.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 7;
                    }

                }
                if (canMove == true && wordBank.isSecondWord)
                {
                    if (needSpawn == true)
                    {
                        Destroy(room4Anim);
                        tempAnim = Instantiate(room8Anim, point8.transform.position, Quaternion.identity);
                        //Destroy(room4Anim);

                        needSpawn = false;
                    }
                    
                    brokeCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point8.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 8;
                    }

                }
            }

            if (lastPoint == 5)
            {
                Debug.Log("Broke Movement las Point5");
                if (canMove == true && wordBank.isFirstWord || wordBank.isSecondWord)
                {
                    if (needSpawn == true)
                    {
                        Destroy(tempAnim);
                        tempAnim = Instantiate(room8Anim, point8.transform.position, Quaternion.identity);
                        //Destroy(room5Anim);

                        needSpawn = false;
                    }
                    
                    brokeCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point8.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 8;
                    }

                }
                //if (canMove == true && wordBank.isSecondWord)
                //{
                //    brokeCeiling.SetActive(false);
                //    Vector3 a = transform.position;
                //    Vector3 b = point8.position;
                //    transform.position = Vector3.Lerp(a, b, t);
                //    if (a == b)
                //    {
                //        canMove = false;
                //        lastPoint = 8;
                //    }

                //}
            }

            if (lastPoint == 6)
            {
                Debug.Log("Broke Movement las Point6");
                if (canMove == true && wordBank.isFirstWord)
                {
                    if (needSpawn == true)
                    {
                        Instantiate(room8Anim, point8.transform.position, Quaternion.identity);

                        needSpawn = false;
                    }
                    
                    brokeCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point8.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 8;
                    }

                }
                if (canMove == true && wordBank.isSecondWord)
                {
                    recruitmentCeiling.SetActive(false);
                    Vector3 a = transform.position;
                    Vector3 b = point9.position;
                    transform.position = Vector3.MoveTowards(a, b, t);
                    if (Vector3.Distance(transform.position, b) < 0.5f)
                    {
                        canMove = false;
                        lastPoint = 9;
                    }

                }
            }
        }
        #endregion
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
