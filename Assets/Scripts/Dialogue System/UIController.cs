using System;
using System.Collections.Generic;
using Conversa.Runtime.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject messageWindow;
    //[SerializeField] private GameObject choiceWindow;
    [SerializeField] private TextMeshProUGUI actorNameText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button nextMessageButton;
    [SerializeField] private GameObject dialogueSystem;

    //[SerializeField] private GameObject choiceOptionButtonPrefab;

    public void ShowMessage(string actor, string message, Sprite avatar, Action onContinue)
    {
        //choiceWindow.SetActive(false);
        messageWindow.SetActive(true);

        actorNameText.text = actor;
        messageText.text = message;

        nextMessageButton.enabled = true;
        nextMessageButton.onClick.RemoveAllListeners();
        nextMessageButton.onClick.AddListener(() => onContinue());
    }
    /*
    public void ShowChoice(string actor, string message, Sprite avatar, List<Option> options)
    {
        messageWindow.SetActive(true);

        UpdateImage(avatar);
        actorNameText.text = actor;
        messageText.text = message;
        nextMessageButton.enabled = false;

        choiceWindow.SetActive(true);

        foreach (Transform child in choiceWindow.transform)
            Destroy(child.gameObject);

        options.ForEach(option =>
        {
            var instance = Instantiate(choiceOptionButtonPrefab, Vector3.zero, Quaternion.identity);
            instance.transform.SetParent(choiceWindow.transform);
            instance.GetComponentInChildren<Text>().text = option.Message;
            instance.GetComponent<Button>().onClick.AddListener(() => option.Advance());
        });
    }*/
    
    public void Hide()
    {
        dialogueSystem.SetActive(false);
        messageWindow.SetActive(false);
        //choiceWindow.SetActive(false);
    }
}