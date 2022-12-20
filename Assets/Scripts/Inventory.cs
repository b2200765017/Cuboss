using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // A list to store the items in the inventory
    List<string> items = new List<string>();

    // A method to add an item to the inventory
    public void AddItem(string itemName)
    {
        items.Add(itemName);
    }

    // A method to remove an item from the inventory
    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);
    }

    // A method to check if the inventory contains a specific item
    public bool ContainsItem(string itemName)
    {
        return items.Contains(itemName);
    }

    // A method to display the items in the inventory
    public void DisplayInventory()
    {
        Debug.Log("Inventory:");
        foreach (string item in items)
        {
            Debug.Log(item);
        }
    }
}