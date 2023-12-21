using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<Sprite> inventoryImages = new List<Sprite>();
    public GameObject spriteBackgroundPrefab;
    public GameObject playerInventory;
    
    public void AddToInventory(Sprite item)
    {
        if (inventoryImages.Count < 5)
        {
            inventoryImages.Add(item);
            UpdateInventory();
        }
        else
            Debug.Log("Inventory is full");
    }
    public void RemoveFromInventory(Sprite item)
    {
        inventoryImages.RemoveAt(inventoryImages.IndexOf(item));
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        foreach (Transform child in playerInventory.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Sprite image in inventoryImages)
        {
            GameObject newSpriteBackground = Instantiate(spriteBackgroundPrefab);
            newSpriteBackground.transform.SetParent(playerInventory.transform);
            newSpriteBackground.GetComponentInChildren<Image>().sprite = image;
        }
    }
}
