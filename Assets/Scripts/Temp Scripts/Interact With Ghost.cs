using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithGhost : MonoBehaviour
{
    private bool _playerEntered;
    public GameObject proximityMessage;

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
