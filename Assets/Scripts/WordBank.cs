using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBank : MonoBehaviour
{
    

    public bool needWords = true;
    public int wordListNum = 1;

    private string firstLetter1 = string.Empty;
    private string firstLetter2 = string.Empty;

    public bool isFirstWord = false;
    public bool isSecondWord = false;

    public bool bedroomChoice = true;
    public bool uniChoice = false;
    public bool studyChoice = false;
    public bool partyChoice = false;
    public bool sportChoice = false;
    public bool trainingChoice = false;

    public Text option1txt;
    public Text option2txt;
    public Text chooseOptiontxt;

    public List<string> originalWords = new List<string>()
    {
        //"Graduation", "Studying", "University"          //training (extra)
        "Broke", "hello", "Sports"
    };

    public List<string> words1 = new List<string>()
    {
        "University", "Sports"
    };

    public List<string> words2 = new List<string>()
    {
        "Studying", "Partying"
    };

    public List<string> words3 = new List<string>()
    {
        "Graduation", "Dropout"
    };

    public List<string> words4 = new List<string>()
    {
        "Partying", "Training"
    };

    public List<string> words5 = new List<string>()
    {
        "Broke", "Broke"
    };

    public List<string> words6 = new List<string>()
    {
        "Injury", "Recruitment"
    };


    public List<string> workingWords = new List<string>();

    private void Awake()
    {
        //workingWords.AddRange(originalWords);                     //
        workingWords.AddRange(words1);
        //Shuffle(workingWords);
        ConvertToLower(workingWords);                             //
    }

    //private void Shuffle(List<string> list)
    //{
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        int random = Random.Range(i, list.Count);
    //        string temporary = list[i];

    //        list[i] = list[random];
    //        list[random] = temporary;
    //    }
    //}

    private void ConvertToLower(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        //if (workingWords.Count != 0)
        //{
        //    newWord = workingWords.Last();
        //    workingWords.Remove(newWord);
        //    workingWords.Remove(workingWords[0]);           //////
        //}

        if (isFirstWord == true)
        {
            newWord = workingWords.First();
        }

        if (isSecondWord == true)
        {
            newWord = workingWords.Last();
        }

        return newWord;
    }

    public void Update()
    {
        if (needWords == true)
        {
            if (wordListNum == 1)
            {
                workingWords.Clear();
                workingWords.AddRange(words1);
                option1txt.text = workingWords[0];
                option2txt.text = workingWords[1];
            }
            if (wordListNum == 2)
            {
                workingWords.Clear();
                workingWords.AddRange(words2);
                Debug.Log("it works words2");
                option1txt.text = workingWords[0];
                option2txt.text = workingWords[1];
            }
            else if (wordListNum == 3)
            {
                workingWords.Clear();
                workingWords.AddRange(words3);
                option1txt.text = workingWords[0];
                option2txt.text = workingWords[1];
            }
            else if (wordListNum == 4)
            {
                workingWords.Clear();
                workingWords.AddRange(words4);
                Debug.Log("it works words2");
                option1txt.text = workingWords[0];
                option2txt.text = workingWords[1];
            }
            else if (wordListNum == 5)
            {
                workingWords.Clear();
                workingWords.AddRange(words5);
                option1txt.text = workingWords[0];
                option2txt.text = workingWords[1];
            }
            else if (wordListNum == 6)
            {
                workingWords.Clear();
                workingWords.AddRange(words6);
                option1txt.text = workingWords[0];
                option2txt.text = workingWords[1];
            }
            ConvertToLower(workingWords);
            needWords = false;
        }
    }
}
