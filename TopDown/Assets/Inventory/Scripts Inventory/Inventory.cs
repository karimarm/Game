using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] cells;
    public GameObject[] slots;
    [SerializeField] private GameObject inventory;
    bool inventoryOn;

    private void Start()
    {
        inventoryOn = true;
    }

    public void InventoryClick()
    {
        if (inventoryOn)            
            inventory.SetActive(false);
        else
            inventory.SetActive(true);
        inventoryOn = !inventoryOn;
    }
}
