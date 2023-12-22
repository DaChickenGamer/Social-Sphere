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
        foreach (var key in _favorabilityDictionary)
        {
            Debug.Log(key.Key + " : " + key.Value);
        }
    }

    public void AddFavorability(string characterName, float favorability)
    {
        _favorabilityDictionary[characterName] += favorability;
    }
    public void RemoveFavorability(string characterName, float favorability)
    {
        _favorabilityDictionary[characterName] -= favorability;
    }
}
