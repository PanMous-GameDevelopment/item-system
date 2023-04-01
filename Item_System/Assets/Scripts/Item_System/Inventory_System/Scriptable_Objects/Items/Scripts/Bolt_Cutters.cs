using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bolt_Cutters Object", menuName = "Inventory System/Items/Bolt_Cutters")]
public class Bolt_Cutters : ItemObject
{
    public void Awake()
    {
        type = ItemType.Bolt_Cutters;
    }
}
