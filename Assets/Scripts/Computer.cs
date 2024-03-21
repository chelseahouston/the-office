using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    public GameObject computerPanel;
    public bool nearComputer;
    public TextMeshProUGUI interactionE, backText;

    // Start is called before the first frame update
    void Start()
    {
        computerPanel.SetActive(false);
        nearComputer = false;
        if (interactionE != null)
            interactionE.enabled = false;
        if (backText != null)
            backText.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (nearComputer)
            {
                LoadComputer();
            }
        }
    }

    public void LoadComputer()
    {
        computerPanel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nearComputer = true;
        if (interactionE != null)
            interactionE.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearComputer = false;
        if (interactionE != null)
            interactionE.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Office");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        computerPanel.SetActive(false);
    }

    public void BackHover()
    {
        if (backText != null)
            backText.enabled = true;
    }

    public void BackHoverExit()
    {
        if (backText != null)
            backText.enabled = false;
    }
}
