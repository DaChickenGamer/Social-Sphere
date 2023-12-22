using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndoorRange : MonoBehaviour
{
    public GameObject proximityMessage;
    private bool _playerEntered;
    private PlayerInteraction _playerInteraction;

    public TMP_InputField nameInputField;
    
    private string _correctName = "magicstunts123";

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        proximityMessage.SetActive(false);
        nameInputField.transform.parent.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (_playerEntered && _playerInteraction.GetIsInteracting() && !nameInputField.transform.parent.gameObject.activeSelf)
            nameInputField.transform.parent.gameObject.SetActive(true);
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

    public void CheckForName()
    {
        if (nameInputField.text == _correctName)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            nameInputField.text = "Wrong Name!";
        }
    }

    public void CloseNameEnter()
    {
        nameInputField.transform.parent.gameObject.SetActive(false);
    }
}
