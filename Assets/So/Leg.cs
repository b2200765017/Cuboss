using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeadItem", menuName = "Items", order = 2)]
public class Leg : ScriptableObject
{
    public bool isBought = false;
    public GameObject item;
    public int itemPrice;
}
