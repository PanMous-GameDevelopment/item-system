using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Measuring_Tape Object", menuName = "Inventory System/Items/Measuring_Tape")]
public class Measuring_Tape : ItemObject
{
    public void Awake()
    {
        type = ItemType.Measuring_Tape;
    }
}
