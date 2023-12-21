using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavorabilityController : MonoBehaviour
{
    public Dictionary<string, float> _favorabilityDictionary = new Dictionary<string, float>();

    private void Awake()
    {
        foreach (DialogueInteractionController dialogueInteractionController in FindObjectsOfType<DialogueInteractionController>())
        {
            _favorabilityDictionary.Add(dialogueInteractionController.character.characterName, 0);
        }
    }

    private void Start()
    {
        Debug.Log(_favorabilityDictionary.Count);
    }

    private void Update()
    {
    }
}
