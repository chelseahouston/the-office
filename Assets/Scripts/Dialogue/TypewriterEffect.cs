using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private TMP_Text textComponent;
    private string originalText;

    void Start()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        StartCoroutine(TypeText());
    }

    public void Initialize(){
        textComponent = GetComponent<TMP_Text>();
        originalText = textComponent.text;
        textComponent.text = "";
    }

    IEnumerator TypeText()
    {
        Initialize();
        foreach (char c in originalText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
