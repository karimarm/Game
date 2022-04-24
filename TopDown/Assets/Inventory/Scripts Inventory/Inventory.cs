using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public void SendMessage(string message)
    {
        int num = Convert.ToInt32(message);
        if (slots[num].transform.childCount > 0)
        {
            switch (slots[num].transform.GetChild(0).gameObject.name)
            {
                case "SmallElixirIcon(Clone)":
                    PlayerHealf.healf++;
                    break;
                case "BigElixirIcon(Clone)":
                    PlayerHealf.healf = PlayerHealf.maxHealf;
                    break;
                case "HeartElixirIcon(Clone)":
                    PlayerHealf.maxHealf++;
                    PlayerHealf.healf++;
                    break;
            }
            cells[num] = false;
            Destroy(slots[num].transform.GetChild(0).gameObject);
        }
    }
}
