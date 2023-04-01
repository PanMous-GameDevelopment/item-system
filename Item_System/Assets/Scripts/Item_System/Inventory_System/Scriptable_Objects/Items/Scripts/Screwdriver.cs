using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Screwdriver Object", menuName = "Inventory System/Items/Screwdriver")]
public class Screwdriver : ItemObject
{
    public void Awake()
    {
        type = ItemType.Screwdriver;
    }
}
