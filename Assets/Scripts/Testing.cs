using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Typer typer;
    public WordBank wordBank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (wordBank.workingWords.Count != 0)
        {
            newWord = wordBank.workingWords.Last();
            wordBank.workingWords.Remove(newWord);
            wordBank.workingWords.Remove(wordBank.workingWords[0]);           //////
        }

        return newWord;
    }
}
