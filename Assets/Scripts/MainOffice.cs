using UnityEngine;

public class MainOffice : MonoBehaviour
{
    public GameObject PausePanel;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            UnPause();
        }
    }

    public void Pause()
    {
        Debug.Log("Pausing...");
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        Debug.Log("Panel Active = " + PausePanel.activeSelf);
    }

    public void UnPause()
    {
        Debug.Log("Un-Pausing...");
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Debug.Log("Panel Active = " + PausePanel.activeSelf);
    }
}
