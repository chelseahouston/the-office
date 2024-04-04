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
        dialogueDB.Add(new Dialogue(6, "Player", "It's not a good idea to search people's desks with colleages in the room.", "Good call...", ""));
        dialogueDB.Add(new Dialogue(7, "Jane", "Ugh, Monday already huh? What do you want?", "Where is everyone today?", "Say nothing"));
        dialogueDB.Add(new Dialogue(8, "John", "Ready for the big presentation today, mate?", "I was born ready!", "Not at all..."));
    }

    public string GetNameByID(int id)
    {
        string name = "";
        foreach (var d in dialogueDB)
        {
            if (d.id == id)
            {
                name = d.personSpeaking;
            }

            switch (name)
            {
                case "Emily":
                    name = name + " (Accounting)";
                    break;
                case "John":
                    name = name + " (Sales)";
                    break;
                case "Jane":
                    name = name + " (Customer Relations)";
                    break;
                case "Charlie":
                    name = name + " (Switchboard)";
                    break;
                case "Sam":
                    name = name + " (IT Support)";
                    break;
                case "Player":
                    name = "";
                    break;
            }
        }

        return name;
    }

    public Sprite GetSpriteByID(int id)
    {    
        foreach (var d in dialogueDB)
        {
            if (d.id == id)
            {
                s = Resources.Load<Sprite>("Characters/SpeechImages/"+ d.personSpeaking.ToLower());
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
