using UnityEngine;

public class MenuSelection : MonoBehaviour
{
    public GameObject[] options;
    public GameObject[] borders;
    public Computer comp;
    private int currentIndex = 0; // index of currently selected option

    private void Start()
    {
        currentIndex = 0;
        foreach (GameObject border in borders)
        {
            if (borders[currentIndex] != border)
            {
                border.SetActive(false);
            }

        }
    }

    void Update()
    {
        // cycle through options with arrows
        if (Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown(KeyCode.W))
        {
            GoToPreviousOption();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) | Input.GetKeyDown(KeyCode.S))
        {
            GoToNextOption();
        }

        // select option highlighted
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.E))
        {
            SelectCurrentOption();
        }
    }

    void GoToPreviousOption()
    {
        borders[currentIndex].gameObject.SetActive(false);
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        borders[currentIndex].gameObject.SetActive(true);
    }

    void GoToNextOption()
    {
        borders[currentIndex].gameObject.SetActive(false);
        if (currentIndex < options.Length - 1)
        {
            if (options[currentIndex + 1].gameObject.activeSelf) // if there is an option after it
            {
                currentIndex++;
            }
        }
        borders[currentIndex].gameObject.SetActive(true);
    }

    void SelectCurrentOption()
    {

        Debug.Log("Selected option: " + options[currentIndex].name);
        comp.SelectOption(options[currentIndex].name);
        currentIndex = 0;
    }

}
