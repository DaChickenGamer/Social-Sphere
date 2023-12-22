using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggManager : MonoBehaviour
{
    public GameObject eggPlatform;
    public GameObject eggPrefab;
    public GameObject timerUI;

    public bool eggHuntStarted = false;
    private bool _isTimerStarted;
    private bool _isTimerOver;
    
    public TextMeshProUGUI timerText;

    public int eggsCollected;
    private int eggCount = 0; // Placeholder

    private bool eggsGenerated = false;

    public bool loseCondition = false;
    
    private float minX, minY, maxX, maxY;

    private List<Vector3> eggLocations;

    [SerializeField] private TextMeshProUGUI _eggCountUI;
    
    private void Start()
    {
        eggLocations = new List<Vector3>();
        eggsCollected = 0;
        Collider2D eggPlatformCollider = eggPlatform.GetComponent<Collider2D>();
        
        _eggCountUI.gameObject.SetActive(false);

        minX = eggPlatformCollider.bounds.min.x;
        maxX = eggPlatformCollider.bounds.max.x;
        minY = eggPlatformCollider.bounds.min.y;
        maxY = eggPlatformCollider.bounds.max.y;
    }
        
    
    private void Update()
    {
        _eggCountUI.text = eggsCollected.ToString() + " / 10 Eggs";
        
        EggGameConditions();
    }

    private void EggGameConditions()
    {
        if(_isTimerStarted)
            Timer();
        if (_isTimerStarted == false && eggsGenerated)
        {
            _eggCountUI.gameObject.SetActive(true);
            timerUI.SetActive(true);
            _isTimerStarted = true;
        }
        if (eggHuntStarted && eggsGenerated == false)
        {
            GenerateEggs();
        }
        if (eggCount == 10)
        {
            eggsGenerated = true;
        }
        if (eggsCollected == 10 || _isTimerOver)
        {
            loseCondition = true;
            timerUI.SetActive(false);
            eggHuntStarted = false;
            _isTimerStarted = false;
            countdownTime = -1;
        }
    }
    private void GenerateEggs()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 randomVector = new Vector3(randomX, randomY, 0);
        bool isNearingExisingEgg = false;

        foreach (Vector3 eggLocation in eggLocations)
        {
            float distance = Vector3.Distance(randomVector, eggLocation);

            if (distance < 10)
            {
                isNearingExisingEgg = true;
                break;
            }
        }
        if (!isNearingExisingEgg)
        {
            eggLocations.Add(randomVector);
            Instantiate(eggPrefab, randomVector, Quaternion.identity);
            eggCount++;   
        }
    }

    private int totalTime = 90;
    private float countdownTime = -1;

    private void Timer()
    {
        if(countdownTime == -1)
            countdownTime = totalTime;
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            timerText.text = ((int)countdownTime).ToString();
        }
        else
        {
            _isTimerOver = true;
        }
    }
}
