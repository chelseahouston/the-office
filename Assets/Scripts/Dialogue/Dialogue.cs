using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue
{
    public int id;
    public string personSpeaking;
    public string dialogue;
    public string option1, option2;

    public Dialogue(int id, string personSpeaking, string dialogue, string option1, string option2)
    {
        this.id = id;
        this.personSpeaking = personSpeaking;
        this.dialogue = dialogue;
        this.option1 = option1;
        this.option2 = option2;
    }


}
