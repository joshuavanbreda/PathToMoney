using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public Triggers triggerScript;
    public VirtualKeyboard.KeyboardFunc keyboard;
    public Movement _movement;
    public ScoreSystem scoreSystem;

    public WordBank wordBank = null;
    public Text wordOutput = null;
    public GameObject wordOutputBackground;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    private string newVirtualLetter = string.Empty;

    public string keysPressed;
    public int posCounter = 1;

    public bool canMove = false;
    public bool chooseWord = false;

    private void Start()
    {
        //SetCurrentWord();
        //wordOutput.gameObject.SetActive(false);\
        //wordOutputBackground.gameObject.SetActive(true);
    }

    private void SetCurrentWord()
    {

        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
        wordOutputBackground.SetActive(true);
    }

    private void Update()
    {
        CheckInput();
        //Instantiate(scoreSystem.money1Particle, scoreSystem.particlePosition.transform.position, Quaternion.identity);
    }

    private void CheckInput()
    {
        //if (Input.anyKeyDown)
        //{
        //    keysPressed = GetVirtualKey(virtualLetter);

        //    if (keysPressed.Length == 1)
        //        EnterLetter(keysPressed);
        //}
    }

    public void GetVirtualKey(string virtualLetter)
    {
        //Debug.Log(virtualLetter);

        keysPressed = virtualLetter;
        if (keysPressed.Length == 1)
            EnterLetter(keysPressed);
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            //if (IsWordComplete())
            //    SetCurrentWord();

            if (IsWordComplete())
            {
                //scoreSystem.GiveScore();                                                              ///////////////////////////
                //SetCurrentWord();                                                                     ///////////////////////////
                StartCoroutine(CannotTypeWait());
                //wordOutput.gameObject.SetActive(false);
                wordOutputBackground.gameObject.SetActive(false);
                //CanMove();
                posCounter += 1;
                _movement.showButtons = true;
                //Instantiate(triggerScript.currentParticle, triggerScript.particlePosition.transform.position, Quaternion.identity);
                
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
        Debug.Log("help me something is broken");
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    public void canType()
    {
        keyboard.gameObject.SetActive(true);
        //wordOutput.gameObject.SetActive(true);
        //wordOutputBackground.gameObject.SetActive(false);
    }
    
    public IEnumerator CannotTypeWait()
    {
        yield return new WaitForSeconds(0.4f);
        keyboard.gameObject.SetActive(false);
    }

    //public IEnumerator CanMove()
    //{
    //    yield return new WaitForSeconds(2f);
    //    //posCounter += 1;
    //    canMove = true;
    //    Debug.Log("yes");
    //}

    public void checkLetterWordSelect(string virtualKey)
    {
        //wordBank.originalWords[1] = "hello";
        string firstLetter1 = wordBank.workingWords[0].Substring(0, 1);
        string firstLetter2 = wordBank.workingWords[1].Substring(0, 1);
        
        if (virtualKey == firstLetter1)
        {
            wordBank.isFirstWord = true;
            wordBank.isSecondWord = false;
        }

        if (virtualKey == firstLetter2)
        {
            wordBank.isSecondWord = true;
            wordBank.isFirstWord = false;
        }

        chooseWord = false;
        SetCurrentWord();

        wordBank.option1txt.gameObject.SetActive(false);
        wordBank.option2txt.gameObject.SetActive(false);
        wordBank.chooseOptiontxt.gameObject.SetActive(false);



    }
}
