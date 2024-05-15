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
        // looking at desks
        dialogueDB.Add(new Dialogue(1, "Player", "This is John's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(2, "Player", "This is Jane's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(3, "Player", "This is Sam's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(4, "Player", "This is Emily's desk.", "Search desk", "Do nothing"));
        dialogueDB.Add(new Dialogue(5, "Player", "This is Charlie's desk.", "Search desk", "Do nothing"));
        // coworkers present, don't search
        dialogueDB.Add(new Dialogue(6, "Player", "It's not a good idea to search people's desks with colleages in the room.", "Good call...", ""));

        // initial dialogues with each NPC
        dialogueDB.Add(new Dialogue(7, "Jane", "Ugh, Monday already huh? What do you want?", "Where is everyone today?", "Say nothing"));
        dialogueDB.Add(new Dialogue(8, "John", "Ready for the big presentation today, mate?", "I was born ready!", "Not at all..."));
        dialogueDB.Add(new Dialogue(9, "Emily", "", "Option1", "Option2"));
        dialogueDB.Add(new Dialogue(10, "Sam", "", "Option1", "Option2"));
        dialogueDB.Add(new Dialogue(11, "Charlie", "", "Option1", "Option2"));
        dialogueDB.Add(new Dialogue(10, "Boss", "", "Option1", "Option2"));

        // can search desks
        dialogueDB.Add(new Dialogue(11, "Player", "There's an ERASER in here", "Take it", "Leave it")); // John's Desk
        dialogueDB.Add(new Dialogue(12, "Player", "There's a PAPERCLIP in here", "Take it", "Leave it")); // Jane's Desk
        dialogueDB.Add(new Dialogue(13, "Player", "There's a USB in here", "Take it", "Leave it")); // Sam's Desk
        dialogueDB.Add(new Dialogue(14, "Player", "There's DUCT TAPE in here", "Take it", "Leave it")); // Charlie's Desk
        dialogueDB.Add(new Dialogue(15, "Player", "There's $50 in here", "Take it", "Leave it")); // Emily's Desk

        // scene 1 dialogue - main office / storage closet
        // Jane
        dialogueDB.Add(new Dialogue(16, "Jane", "John is over there. He knows more than me.", "...Oh ok", ""));
        dialogueDB.Add(new Dialogue(17, "Jane", "Oh.. maybe the conference room. Probably time I head in there too.", "Cool, see you in there!", ""));
        // John
        dialogueDB.Add(new Dialogue(18, "John", "I have some special candy in my car that might help, be right back!", "...uhh", ""));
        dialogueDB.Add(new Dialogue(19, "John", "Awesome. Good luck!", "Thanks!", ""));
        // Emily
        dialogueDB.Add(new Dialogue(20, "Emily", "I'm so glad you're here! I can't reach the printer paper in the storage room. Can you help me, please?", "Sure, I'll come and help.", "Sorry, I can't right now."));
        dialogueDB.Add(new Dialogue(21, "Emily", "Time for the REAL assistant manager to give your... I mean MY presentation.", "...!?!", ""));
        // Player (storage closet)
        dialogueDB.Add(new Dialogue(22, "Player", "She's actually locked me in here...", "I need to get out!", ""));
        dialogueDB.Add(new Dialogue(23, "Player", "Oh this looks like the keycard to the Boss' office", "Take it", "Leave it"));
        dialogueDB.Add(new Dialogue(24, "Player", "I could probably pick this lock if I had the right tools", "I believe I have the tools", "I don't have the tools, I'll have to wait until I'm let out"));
        dialogueDB.Add(new Dialogue(25, "Player", "Ah the lockpick broke! Perhaps I could have made it sturdier.", "Time to get outa here!", ""));
        // didn't go into storage closet
        dialogueDB.Add(new Dialogue(26, "Emily", "Ugh.. Rude.", "...", ""));
        dialogueDB.Add(new Dialogue(27, "Sam", "Hey! Did you hear the rumour?", "What rumour?", ""));
        dialogueDB.Add(new Dialogue(28, "Sam", "Apparently the Boss is hooking up with Emily! Not that there's anything wrong with office relationships in my opinion. What's your take on them?", "I have no problem with them.", "It's not something I agree with."));
        dialogueDB.Add(new Dialogue(29, "Sam", "So in that case, would you like to have lunch together today?", "It's a date", "I'm flattered but no, thank you."));

        // scene 2 dialogue - presentation / conference room

        // scene 3 dialogue - lunch cafeteria

        // scene 4 dialogue - bathroom (lunch break)

        // scene 5 dialogue - main office / boss office (lunch break)

        // scene 6 dialogue - main office final scene

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
