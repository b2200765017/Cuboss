using UnityEngine;

[CreateAssetMenu(fileName = "HeadItem", menuName = "Items", order = 1)]
public class Head : ScriptableObject
{
    public bool isBought = false;
    public GameObject item;
    public int itemPrice;
}
