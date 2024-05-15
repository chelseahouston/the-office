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
        dialogueDB.Add(new Dialogue(11, "Player", "There's an ERASER in here", "Take and add to inventory", "Leave it")); // John's Desk
        dialogueDB.Add(new Dialogue(12, "Player", "There's a PAPERCLIP in here", "Take and add to inventory", "Leave it")); // Jane's Desk
        dialogueDB.Add(new Dialogue(13, "Player", "There's a USB in here", "Take and add to inventory", "Leave it")); // Sam's Desk
        dialogueDB.Add(new Dialogue(14, "Player", "There's DUCT TAPE in here", "Take and add to inventory", "Leave it")); // Charlie's Desk
        dialogueDB.Add(new Dialogue(15, "Player", "There's $50 in here", "Take and add to inventory", "Leave it")); // Emily's Desk

        // scene 1 dialogue - main office / storage closet
        // Jane
        dialogueDB.Add(new Dialogue(16, "Jane", "John is over there. He knows more than me.", "...Oh ok", ""));
        dialogueDB.Add(new Dialogue(17, "Jane", "Oh.. maybe the conference room. Probably time I head in there too.", "Cool, see you in there!", ""));
        // John
        dialogueDB.Add(new Dialogue(18, "John", "I have some special candy in my car that might help, be right back!", "...uhh", ""));
        dialogueDB.Add(new Dialogue(19, "John", "Awesome. Good luck!", "Thanks!", ""));
        dialogueDB.Add(new Dialogue(20, "John", "Here, have these PILLS. They help with my anxiety and actually make me so calm I could sleep!", "Accept and add to inventory", "Decline them"));
        // Emily
        dialogueDB.Add(new Dialogue(21, "Emily", "I'm so glad you're here! I can't reach the printer paper in the storage room. Can you help me, please?", "Sure, I'll come and help.", "Sorry, I can't right now."));
        dialogueDB.Add(new Dialogue(22, "Emily", "Time for the REAL assistant manager to give your... I mean MY presentation.", "...!?!", ""));
        // Player (storage closet)
        dialogueDB.Add(new Dialogue(23, "Player", "She's actually locked me in here...", "I need to get out!", ""));
        dialogueDB.Add(new Dialogue(24, "Player", "Oh this looks like the keycard to the Boss' office", "Take it", "Leave it"));
        dialogueDB.Add(new Dialogue(25, "Player", "I could probably pick this lock if I had the right tools", "I believe I have the tools", "I don't have the tools, I'll have to wait until I'm let out"));
        dialogueDB.Add(new Dialogue(26, "Player", "Ah the lockpick broke! Perhaps I could have made it sturdier.", "Time to get outa here!", ""));
        // didn't go into storage closet
        dialogueDB.Add(new Dialogue(27, "Emily", "Ugh.. Rude.", "...", ""));
        dialogueDB.Add(new Dialogue(28, "Sam", "Hey! Did you hear the rumour?", "What rumour?", ""));
        dialogueDB.Add(new Dialogue(29, "Sam", "Apparently the Boss is hooking up with Emily! Not that there's anything wrong with office relationships in my opinion. What's your take on them?", "I have no problem with them.", "It's not something I agree with."));
        dialogueDB.Add(new Dialogue(30, "Sam", "So in that case, would you like to have lunch together today?", "It's a date", "I'm flattered but no, thank you."));

        // scene 2 dialogue - presentation / conference room
        dialogueDB.Add(new Dialogue(31, "Cleaning Guy", "Hey I heard you in here, be careful this lock isn't working too well.", "Thank you!", ""));
        // presentation good
        dialogueDB.Add(new Dialogue(32, "Boss", "Hey that was a great presentation! Good job. I'm super proud of you.", "Thanks, Bossman.", ""));
        // presentation bad
        dialogueDB.Add(new Dialogue(33, "Boss", "What was that all about? I'll speak with you in my office before you take lunch.", "...sure.", ""));

        // explore conference room
        dialogueDB.Add(new Dialogue(34, "Player", "There's a BATTERY here", "Take and add to inventory", "Leave it"));
        dialogueDB.Add(new Dialogue(35, "Player", "There are a pair of SCISSORS here", "Take and add to inventory", "Leave them"));

        // scene 3 dialogue - lunch
        //boss office
        dialogueDB.Add(new Dialogue(36, "Boss", "I don't want to hear any excuses. You were supposed to give a great presentation today, and you failed to deliver.", "...", ""));
        dialogueDB.Add(new Dialogue(37, "Boss", "That's the end of it. Go and eat, and don't expect your missed lunch time back. Back in the office 14:30. Now, go.", "Yes, Sir", ""));
        // cafe
        dialogueDB.Add(new Dialogue(38, "Player", "Hmm, should I get a coffee?", "Yes and add to inventory", "No, leave it"));
        dialogueDB.Add(new Dialogue(39, "Charlie", "Hey! Come sit!", "Sure!", ""));
        dialogueDB.Add(new Dialogue(40, "Sam", "Hey, how's it going?", "Good, thanks!", "Good. Here, I got you a coffee [Give Sleepy Coffee]"));
        dialogueDB.Add(new Dialogue(41, "Sam", "Hey, how's it going?", "Good, thanks!", ""));
        dialogueDB.Add(new Dialogue(42, "Sam", "Isn't coffee supposed to make you more alert? This is making me sleepy! I'll get a nap in before lunch is over.", "Nap well!", ""));

        // if coming from boss office
        dialogueDB.Add(new Dialogue(46, "Sam", "Hey, turns out the rumours are true!", "What do you mean?", ""));
        dialogueDB.Add(new Dialogue(47, "Sam", "The Boss and Emily are so hooking up!! Being the IT guy, my USB contains all their credentials. I miiiiight have snooped on Emily's PC and saw so many X-Rated images of her and the Bossman together! I even printed some..", "You.. printed them?!", ""));
        dialogueDB.Add(new Dialogue(48, "Sam", "Yeah! Copies are available... for a price.", "Would you take $50", "No thanks, mate."));
        dialogueDB.Add(new Dialogue(49, "Sam", "Yeah! Copies are available... for a price.","No thanks, mate.", ""));

        // scene 4 dialogue - bathroom (lunch break)
        dialogueDB.Add(new Dialogue(50, "Player", "There's a FOOTSTOOL here", "Take and add to inventory", "Leave it"));
        dialogueDB.Add(new Dialogue(51, "Player", "There's a DAMAGED WIRE sticking out of the light", "I'll need something to reach it", ""));
        dialogueDB.Add(new Dialogue(52, "Player", "There's a DAMAGED WIRE sticking out of the light", "Use FOOTSTOOL and add to inventory", "Leave it"));

        // scene 5 dialogue - main office / boss office (lunch break)
        // search PCs?
        dialogueDB.Add(new Dialogue(53, "Player", "This is Emily's Computer", "Use USB credentials to access", "Leave it alone"));
        dialogueDB.Add(new Dialogue(54, "Player", "This is Sam's Computer", "Use USB credentials to access", "Leave it alone"));
        dialogueDB.Add(new Dialogue(55, "Player", "This is Charlie's Computer", "Use USB credentials to access", "Leave it alone"));
        dialogueDB.Add(new Dialogue(56, "Player", "This is John's Computer", "Use USB credentials to access", "Leave it alone"));
        dialogueDB.Add(new Dialogue(57, "Player", "This is Jane's Computer", "Use USB credentials to access", "Leave it alone"));
        // anything on them?
        dialogueDB.Add(new Dialogue(58, "Player", "OMG! There is EVIDENCE on here that Emily is embezzling money from the company!", "Print evidence", "Leave computer alone")); // Emily
        dialogueDB.Add(new Dialogue(59, "Player", "Sam's PC is such a mess I can't even comprehend it right now. Damm IT people!", "Leave computer alone", "")); // Sam
        dialogueDB.Add(new Dialogue(60, "Player", "Aw, Charlie's desktop wallpaper is of his cat, Milo. How cute!", "Leave computer alone", "")); // Charlie
        dialogueDB.Add(new Dialogue(61, "Player", "Wow, the most amazing this on here is John's sales stats. That dude can SELL!", "Leave computer alone", "")); // John
        dialogueDB.Add(new Dialogue(62, "Player", "Jane's computer always makes a weird noise. Probably best I don't mess and explain how it's now broken...", "Leave computer alone", "")); // Jane

        // boss' office
        dialogueDB.Add(new Dialogue(63, "Player", "If I attach this evidence to an official report I can get Emily off my back for good! I'll need to get a document from the Boss' office before he returns from lunch.", "I need to find his keycard.", ""));
        dialogueDB.Add(new Dialogue(64, "Player", "If I attach this evidence to an official report I can get Emily off my back for good! I'll need to get a document from the Boss' office before he returns from lunch.", "Use keycard and enter office.", ""));
        dialogueDB.Add(new Dialogue(65, "Player", "The document I need is in this filing cabinet", "Use lockpick", "I'll just show the Boss later"));
        dialogueDB.Add(new Dialogue(66, "Player", "The document I need is in this filing cabinet", "I'll just show the Boss later", ""));
        dialogueDB.Add(new Dialogue(67, "Player", "Perfect! But if I want this to look legitimate I need to use the Company Stamp. Should be in the Boss' desk", "Search Desk", "I'll just show the Boss later"));
        dialogueDB.Add(new Dialogue(68, "Player", "Found it!", "Take and add to inventory", "Leave it. I'll just show the Boss later"));
        dialogueDB.Add(new Dialogue(69, "Player", "Now all I need to do is create the report with the stamp and evidence and Fax it to Corporate", "...", ""));


        // scene 6 dialogue - main office final scene
        // SL1
        dialogueDB.Add(new Dialogue(70, "Boss", "Emily. Corporate are here. Can you come into my office, please?", "[CONTINUE]", ""));
        dialogueDB.Add(new Dialogue(71, "Boss", "Sam, it seems information was obtained illigitimately from Emily's computer through your USB credentials.", "[CONTINUE]", ""));
        dialogueDB.Add(new Dialogue(72, "Sam", "My USB is missing from my desk. Someone must have taken it and used it.", "[CONTINUE]", ""));
        dialogueDB.Add(new Dialogue(73, "Boss", "Everyone's belongings will be searched and the culprit, along with Emily, immediately dismissed.", "Uh oh...", ""));
        dialogueDB.Add(new Dialogue(74, "Sam", "I haven't used my USB today, it's still in it's place in my desk. Here you go.", "[CONTINUE]", ""));
        dialogueDB.Add(new Dialogue(75, "Sam", "Thank you, Sam. Unfortunately, Emily will no longer be working with us. Please say your goodbyes outside of work hours.", "It worked!", ""));

        // SL2
        dialogueDB.Add(new Dialogue(76, "Sam", "ARE YOU F****** KIDDING ME, CHARLIE?", "What the hell?...", ""));
        dialogueDB.Add(new Dialogue(77, "Sam", "SO MANY SIGNS I'VE GIVEN YOU THAT I LOVE YOU AND YOU ASK ANOTHER PERSON OUT ON A DATE IN FRONT OF ME?!", "Oh no.", ""));
        dialogueDB.Add(new Dialogue(78, "Sam", "How will you like them with a baseball shaped hole in their head?!", "Use Tazor", ""));
        dialogueDB.Add(new Dialogue(79, "Sam", "How will you like them with a baseball shaped hole in their head?!", "OH SHI-", ""));

        // SL3
        dialogueDB.Add(new Dialogue(80, "Player", "Got some images you might like to see", "Show X-Rated images", ""));
        dialogueDB.Add(new Dialogue(81, "Boss", "What the- How did you get these?!", "Demand they resign", "Feel sorry for the boss and hand them over"));
        dialogueDB.Add(new Dialogue(82, "Player", "I'll keep them to myself if you stand down and promote me in your position.", "[CONTINUE]", ""));
        dialogueDB.Add(new Dialogue(83, "Boss", "I'll never get a management position again if this gets out. FINE. But keep one eye open.", "[CONTINUE]", ""));
        dialogueDB.Add(new Dialogue(84, "Boss", "You being aware of this affair is not going to bode well for me. Without the images you have no proof of my wrongdoing. Unfortunately, I must dismiss you.", "Wait.. What?!", ""));
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
