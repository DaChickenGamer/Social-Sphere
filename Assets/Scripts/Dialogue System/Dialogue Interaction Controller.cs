using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueInteractionController : MonoBehaviour
{
    private bool playerEntered;
    private Character character;

    private ConversaController conversaController;
    private void Start()
    {
        conversaController = FindObjectOfType<ConversaController>();
        
        List<Character> characters = new List<Character>(Resources.LoadAll<Character>("Characters"));
        
        foreach (Character character in characters)
        {
           Debug.Log(character.characterName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
        }
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
        }
    }

    private void CheckForNpcName()
    {
        switch (gameObject.name)
        {
            case "Yeva":
                break;
            case "Kris":
                break;
            case "Rita":
                break;
            case "Ilona":
                break;
            case "Jessi":
                break;
            case "Ayla":
                break;
            case "Thomas":
                break;
            case "Sarah":
                break;
        }
    }
}
