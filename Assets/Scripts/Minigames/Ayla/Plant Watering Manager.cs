using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWateringManager : MonoBehaviour
{
    public GameObject plantSpawningPlatform;
    public GameObject plantPrefab;

    public Sprite wateringCanSprite;
    
    public bool plantWateringStarted = false;
    [SerializeField] private bool generatePlants;
    private int maxPlantCount = 5;
    public int plantsWatered;

    private PlayerInventory playerInventory;
    
    private float platformMaxX;
    private float platformMinX;
    private float platformMiddleY;

    private void Start()
    {
        plantsWatered = 0;
        Collider2D plantCollider = plantSpawningPlatform.GetComponent<Collider2D>();
        
        playerInventory = FindObjectOfType<PlayerInventory>();
        
        platformMaxX = plantCollider.bounds.max.x;
        platformMinX = plantCollider.bounds.min.x;
        platformMiddleY = plantCollider.bounds.center.y;
    }

    private void Update()
    {
        if (generatePlants)
        {
            for (int i = 0; i < maxPlantCount; i++)
            {
                // Needs to account for size of the object
                Instantiate(plantPrefab, new Vector3(((((platformMaxX - platformMinX) )/maxPlantCount) * i) + platformMinX, platformMiddleY, 0), Quaternion.identity);
            }
            generatePlants = false;
        }

        if (plantWateringStarted)
        {
            playerInventory.AddToInventory(wateringCanSprite);
        }
    }
}
