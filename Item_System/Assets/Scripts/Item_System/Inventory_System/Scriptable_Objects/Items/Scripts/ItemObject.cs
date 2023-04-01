using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
   Bottle,
   Machete,
   Measuring_Tape,
   Screwdriver,
   Hammer,
   Bolt_Cutters,
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
