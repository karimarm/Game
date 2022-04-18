using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thing : MonoBehaviour
{
    [SerializeField] private GameObject image;
    Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("0");
        if (other.CompareTag("Player"))
        {
            Debug.Log("1");
            for (int i = 0; i < inventory.cells.Length; i++)
            {
                Debug.Log("2");
                if (inventory.cells[i] == false)
                {
                    Debug.Log("3");
                    inventory.cells[i] = true;
                    Debug.Log("4");
                    Instantiate(image, inventory.slots[i].transform);
                    Debug.Log("5");
                    Destroy(gameObject);
                    Debug.Log("6");
                    break;
                }
            }
        }
    }
}