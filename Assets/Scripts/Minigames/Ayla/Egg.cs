using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private bool playerEntered;
    private bool isInteracting;

    private Collider2D playerCollider;
    public GameObject eggManager;

    private EggManager _eggManager;

    private void Start()
    {
        _eggManager = FindObjectOfType<EggManager>();
    }

    private void Update()
    {
        if (_eggManager.loseCondition)
            Destroy(gameObject);
        if (playerEntered && isInteracting == false)
        {
            isInteracting = playerCollider.GetComponent<PlayerInteraction>().GetIsInteracting();
        }
        else if (playerEntered && isInteracting)
        { 
            _eggManager.eggsCollected++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider = other;
            playerEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerEntered = false;
    }
}
