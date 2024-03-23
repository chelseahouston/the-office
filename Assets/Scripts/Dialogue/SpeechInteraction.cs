using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechInteraction : MonoBehaviour
{
    public GameObject character, speechPanel;
    public Image charImg;
    public TextMeshProUGUI text, option1, option2;
    public DialogueDatabase dialogueDatabase;
    public TypewriterEffect typeFX;

    // Start is called before the first frame update
    void Start()
    {
        charImg = character.GetComponent<Image>();
        
        dialogueDatabase = GameObject.Find("Data").GetComponent<DialogueDatabase>();
        speechPanel.SetActive(false);
    }

    public void Speech(int id)
    {
        if (id != 0)
        {
            speechPanel.SetActive(true);
            charImg.sprite = dialogueDatabase.GetSpriteByID(id);
            if (charImg.sprite != null)
            {
                Debug.Log("image set!");
            }
            else
            {
                Debug.Log("Img = null");
            }
            text.text = dialogueDatabase.GetTextByID(id);
            typeFX = text.GetComponent<TypewriterEffect>();
            option1.text = dialogueDatabase.GetOption1ByID(id);
            option2.text = dialogueDatabase.GetOption2ByID(id);
            typeFX.StartTyping();
        }
    }

    public void Option1()
    {
        speechPanel.SetActive(false);
    }

    public void Option2()
    {
        speechPanel.SetActive(false);
    }

}
