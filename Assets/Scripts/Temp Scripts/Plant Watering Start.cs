using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWateringStart : MonoBehaviour
{
    private bool _playerEntered;
    public GameObject proximityMessage;
    
    private PlayerInteraction _playerInteraction;
    private PlantWateringManager _plantWateringManager;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        _plantWateringManager = FindObjectOfType<PlantWateringManager>();
    }
    private void Update()
    {
        if (_playerEntered && _playerInteraction.GetIsInteracting() && _plantWateringManager.plantWateringStarted == false)
        {
            _plantWateringManager.plantWateringStarted = true;
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
