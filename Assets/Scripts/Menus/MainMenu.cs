using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MainOffice mainOfficeScript;
    public SceneManagement sceneManagement;

    private void Start()
    {
        sceneManagement = GameObject.Find("SceneManager").GetComponent<SceneManagement>();
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

}
