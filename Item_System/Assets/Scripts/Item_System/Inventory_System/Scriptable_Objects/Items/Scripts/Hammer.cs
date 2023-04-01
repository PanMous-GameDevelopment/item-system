using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hammer Object", menuName = "Inventory System/Items/Hammer")]
public class Hammer : ItemObject
{
    public void Awake()
    {
        type = ItemType.Hammer;
    }
}
