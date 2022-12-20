using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Item
{
    
}

public class Market : MonoBehaviour
{
    // A dictionary to store the available items and their prices
    Dictionary<string, int> items = new Dictionary<string, int>()
    {
        { "Potion", 50 },
        { "Sword", 100 },
        { "Shield", 75 },
        { "Armor", 200 }
    };

    // A variable to store the player's gold
    public int gold = 500;

    // A method to display the available items and their prices
    public void DisplayItems()
    {
        foreach (KeyValuePair<string, int> item in items)
        {
            Debug.Log(item.Key + ": " + item.Value + " gold");
        }
    }

    // A method to purchase an item
    public void PurchaseItem(string itemName)
    {
        // Check if the item is available
        if (items.ContainsKey(itemName))
        {
            // Get the price of the item
            int price = items[itemName];

            // Check if the player has enough gold
            if (gold >= price)
            {
                // Deduct the price from the player's gold
                gold -= price;

                // Add the item to the player's inventory
                // (you would need to create an inventory system to do this)
                Debug.Log("Purchased " + itemName + " for " + price + " gold");
            }
            else
            {
                Debug.Log("Not enough gold to purchase " + itemName);
            }
        }
        else
        {
            Debug.Log(itemName + " is not available in the market");
        }
    }
}