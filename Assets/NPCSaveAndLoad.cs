using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSaveAndLoad : MonoBehaviour
{
    public GameObject dialogueBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }
}
