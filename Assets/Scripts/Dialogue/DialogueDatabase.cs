using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDatabase : MonoBehaviour
{
    public List<Dialogue> dialogueDB = new List<Dialogue>();
    public Sprite s;

    // Start is called before the first frame update
    void Start()
    {
        ConfigureDialogue();
    }

    public void ConfigureDialogue()
    {
        dialogueDB.Clear();
        dialogueDB.Add(new Dialogue(1, "Player", "This is John's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(2, "Player", "This is Jane's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(3, "Player", "This is Sam's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(4, "Player", "This is Emily's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(5, "Player", "This is Charlie's desk.", "Search desk", "Do nothing"));
    }

    public Sprite GetSpriteByID(int id)
    {    
        foreach (var d in dialogueDB)
        {
            if (d.id == id)
            {
                switch (d.personSpeaking)
                {
                    case "Player":
                        s = Resources.Load<Sprite>("Characters/SpeechImages/player");
                        if (s != null)
                        {
                            Debug.Log("Sprite set to path: Characters/SpeechImages/player");
                            Debug.Log(s.ToString());
                        }
                        else
                        {
                            Debug.Log("S is null");
                        }
                        break;
                }
            }

        }
        return s;
    }

    public string GetTextByID(int id)
    {
        string s = null;
        foreach (var d in dialogueDB)
        {
            if (d.id == id)
            {
                s = d.dialogue;
            }
        }

        return s;
    }

    public string GetOption1ByID(int id)
    {
        string s = null;
        foreach (var d in dialogueDB)
        {
            if (d.id == id)
            {
                s = d.option1;
            }
        }

        return s;
    }

    public string GetOption2ByID(int id)
    {
        string s = null;
        foreach (var d in dialogueDB)
        {
            if (d.id == id)
            {
                s = d.option2;
            }
        }

        return s;
    }

}
