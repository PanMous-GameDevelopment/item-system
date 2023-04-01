using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bottle Object", menuName = "Inventory System/Items/Bottle")]
public class Bottle : ItemObject
{
    public void Awake()
    {
        type = ItemType.Bottle;
    }
}
