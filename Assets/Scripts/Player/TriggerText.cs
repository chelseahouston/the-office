using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// script to show text when player is close, and disappear when player walks away

public class TriggerText : MonoBehaviour
{
    public GameObject thisText;

    // Start is called before the first frame update
    void Start()
    {
        thisText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && thisText != null)
        {
            thisText.SetActive(true)    ;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && thisText != null)
        {
          
            thisText.SetActive(false);
        }
    }


}
