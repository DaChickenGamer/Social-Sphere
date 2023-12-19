using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggManager : MonoBehaviour
{
    public GameObject eggPlatform;
    public GameObject eggPrefab;

    public bool eggHuntStarted = false;

    private int eggCount = 0; // Placeholder
 
    private float minX, minY, maxX, maxY;

    private List<Vector3> eggLocations;
    
    private void Start()
    {
        eggLocations = new List<Vector3>();
        
        Collider2D eggPlatformCollider = eggPlatform.GetComponent<Collider2D>();

        minX = eggPlatformCollider.bounds.min.x;
        maxX = eggPlatformCollider.bounds.max.x;
        minY = eggPlatformCollider.bounds.min.y;
        maxY = eggPlatformCollider.bounds.max.y;
    }

    private void Update()
    {
        if (eggCount < 10 && eggHuntStarted)
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
        else if (eggCount == 10 && eggHuntStarted)
        {
            eggHuntStarted = false;
        }
    }
}
