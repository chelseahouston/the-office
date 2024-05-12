using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechInteraction : MonoBehaviour
{
    public GameObject character, speechPanel, option1panel, option2panel;
    public Image charImg;
    public TextMeshProUGUI text, option1, option2, speakingName;
    public DialogueDatabase dialogueDatabase;
    public TypewriterEffect typeFX;
    public int id;
    public bool coworkerpresent, dialogueOpen;


    // Start is called before the first frame update
    void Start()
    {
        charImg = character.GetComponent<Image>();
        
        dialogueDatabase = GameObject.Find("Data").GetComponent<DialogueDatabase>();
        speechPanel.SetActive(false);
        coworkerpresent = false;
        dialogueOpen = false;
    }

    public void Speech(int id)
    {
        if (id != 0)
        {
            speechPanel.SetActive(true);
            dialogueOpen = true;
            charImg.sprite = dialogueDatabase.GetSpriteByID(id);
            if (charImg.sprite != null)
            {
                Debug.Log("image set!");
            }
            else
            {
                Debug.Log("Img = null");
            }
            speakingName.text = dialogueDatabase.GetNameByID(id);
            text.text = dialogueDatabase.GetTextByID(id);
            typeFX = text.GetComponent<TypewriterEffect>();
            option1.text = dialogueDatabase.GetOption1ByID(id);
            option2.text = dialogueDatabase.GetOption2ByID(id);

            if (option1.text == null || option1.text == "")
            {
                option1panel.SetActive(false);
            }
            else
            {
                if (!option1panel.activeSelf)
                {
                    option1panel.SetActive(true);
                }
            }

            if (option2.text == null || option2.text == "")
            {
                option2panel.SetActive(false);
            }
            else
            {
                if (!option2panel.activeSelf)
                {
                    option2panel.SetActive(true);
                }
            }
            this.id = id;
            typeFX.StartTyping();
        }
    }

    public void SelectOption(string option)
    {
        if (option == "Option1")
        {
            Option1();
        }
        else { Option2(); }

        dialogueOpen = false;
    }

    public void Option1()
    {
        speechPanel.SetActive(false);
        if (id > 0 && id < 6) // if searching desks
        {
            DetectPeoplePresent();
            if (coworkerpresent) 
            { 
                Speech(6); // cant search when coworers present!
            }
        }else
        {
            // nothing yet...
        }

    }

    public void Option2()
    {
        speechPanel.SetActive(false);
    }

    public void DetectPeoplePresent()
    {
        GameObject[] coworkers = GameObject.FindGameObjectsWithTag("Co-worker");

        if (coworkers.Length > 0)
        {
            coworkerpresent = true;
            Debug.Log("Coworker(s) are around!");
        }
        else
        {
            coworkerpresent = false;
            Debug.Log("NO coworker(s) around!");
        }
    }

}
