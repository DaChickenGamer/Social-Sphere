using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private bool _watered;

    private PlantWateringManager plantWateringManager;
    private PlayerInteraction playerInteraction;

    private bool playerEntered;

    private void Awake()
    {
        plantWateringManager = FindObjectOfType<PlantWateringManager>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void Update()
    {
        if (playerEntered && _watered == false && plantWateringManager.plantWateringStarted && playerInteraction.GetIsInteracting())
        {
            _watered = true;
            plantWateringManager.plantsWatered++;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            playerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerEntered = false;
    }
}
