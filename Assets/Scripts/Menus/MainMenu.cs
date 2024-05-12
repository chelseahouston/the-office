using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MainOffice mainOfficeScript;
    public SceneManagement sceneManagement;
    public GameObject hintScreen;
    public GameObject hintButton;

    private void Start()
    {
        sceneManagement = GameObject.Find("SceneManager").GetComponent<SceneManagement>();
        hintScreen.SetActive(false);
    }

    public void Resume()
    {
        mainOfficeScript.UnPause();
    }

    public void RestartRoom()
    {
        string currentRoom = SceneManager.GetActiveScene().name;
        sceneManagement.LoadAndSet(currentRoom);
        Time.timeScale = 1f;
    }

    public void RestartDay()
    {
        sceneManagement.LoadAndSet("StartCubicleScene");
        Time.timeScale = 1f;
    }

    public void LoadHints()
    {
        hintScreen.SetActive(true);
        hintButton.SetActive(false);

    }

    public void ExitHints()
    {
        hintScreen.SetActive(false);
        hintButton.SetActive(true);
    }



}
