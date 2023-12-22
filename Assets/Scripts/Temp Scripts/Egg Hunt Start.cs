using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggHuntStart : MonoBehaviour
{
    private bool _playerEntered;
    public GameObject proximityMessage;
    private EggManager _eggManager;
    private PlayerInteraction _playerInteraction;
    
    private void Start()
    {
        _eggManager = FindObjectOfType<EggManager>();
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
    }

    private void Update()
    {
        if (_playerEntered && _playerInteraction.GetIsInteracting() && _eggManager.eggHuntStarted == false)
        {
            _eggManager.eggHuntStarted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            proximityMessage.SetActive(true);
            _playerEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            proximityMessage.SetActive(false);
            _playerEntered = false;
        }
    }
}
