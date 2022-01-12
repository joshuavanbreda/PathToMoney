using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Tabtale.TTPlugins;

public class GameController : MonoBehaviour
{
    public bool startGame;

    public Button startBtn;
    public Button restartBtn;

    // Start is called before the first frame update
    private void Awake()
    {
        // Initialize CLIK Plugin
        TTPCore.Setup();
        // Your code here
        startBtn.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startGame = true;
        startBtn.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
