using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMNS;
    Dictionary<InventorySlot, GameObject> itemsDisplay = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay(); // Creates the inventory display at the start of the level.
    }

    void Update()
    {
        UpdateDisplay(); // Updates the display at every frame.
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++) // For each item in the inventory.
        { // If the item already exists in the list then it displays its amount.
            if (itemsDisplay.ContainsKey(inventory.Container[i]))
            {
                itemsDisplay[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            } // If the item doesnt exist, then it instantiates a prefab of the item slot representing the item and it adds it to the inventory.
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform); // Instantiate the slot prefab.
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i); // Set the position of the RectTransform component of the new object based on the index i, using the GetPosition() function.                                                                                 
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0"); // Set the text amount of the prefab based on the amount of the object inside the inventory.
                itemsDisplay.Add(inventory.Container[i], obj); // Add the item in the inventory and the new object to the itemsDisplay dictionary.                                                             
            }


        }
    }

    // Creates the display for each item in the invetory. It will be empty since the inventory is empty at the start of the game.
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplay.Add(inventory.Container[i], obj);
        }
    }

    // Creates the position for each slot in the inventory UI depending on the variables given.
    public Vector3 GetPosition(int i)
    {
        // Calculates the X and Y position based on the index and the UI variables.
        float x = X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS));
        float y = Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMNS));

        // Returns the position as a Vector3.
        return new Vector3(x, y, 0f);
    }
}
