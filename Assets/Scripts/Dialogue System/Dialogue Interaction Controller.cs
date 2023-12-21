using System;
using System.Collections;
using System.Collections.Generic;
using Conversa.Runtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueInteractionController : MonoBehaviour
{
    private bool playerEntered;
    public Character character;

    private ConversaController _conversaController;
    private PlayerInteraction _playerInteraction;
    
    private void Start()
    {
        _conversaController = FindObjectOfType<ConversaController>();
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
    }

    private void Update()
    {
        if (playerEntered && _playerInteraction.GetIsInteracting())
        {
            _conversaController.conversation = character.characterConversation;
            _conversaController.HandleStartConversation();
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
}
