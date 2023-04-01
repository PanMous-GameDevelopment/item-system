using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("Interaction UI")]
    public Camera mainCamera;
    public float interactionDistance = 2f;
    public GameObject interactionUI;

    [Header("Inventory UI")]
    public GameObject inventoryUI;
    private bool inventoryIsOpen = false;
    public InventoryObject inventory;

    void Update()
    {
        DetectInteractableObject();

        // Inventory.
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryIsOpen == false) // Opens the inventory UI.
            {
                OpenInventory();
                inventoryIsOpen = true;
            }
            else if (inventoryIsOpen == true) // Closes the inventory UI.
            {
                CloseInventory();
                inventoryIsOpen = false;
            }
        }
    }

    void DetectInteractableObject()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitInteractable = false;

        if (Physics.Raycast(ray, out hit, interactionDistance)) // Cast raycast.
        {
            if ((hit.collider.gameObject.layer == 6)) // If the object is of layer 6 then activate the interaction UI element.
                hitInteractable = true;
        }

        interactionUI.SetActive(hitInteractable);
    }

    void OpenInventory()
    {
        inventoryUI.SetActive(true);
    }

    void CloseInventory()
    {
        inventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
