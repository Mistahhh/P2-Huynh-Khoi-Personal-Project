using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public GameObject activeScreen;
    public GameObject titleScreen;
    public GameObject gameoverScreen;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        titleScreen.gameObject.SetActive(true);
        activeScreen.gameObject.SetActive(true);
        gameoverScreen.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {         
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        activeScreen.gameObject.SetActive(true);
        gameoverScreen.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        
        isGameActive = false;
        //Turn off game when game over, turn on visibillity for restart button and game over text
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
        isGameActive = true;

        titleScreen.gameObject.SetActive(false);

        //Make title screen go away if the game starts
    }
}
