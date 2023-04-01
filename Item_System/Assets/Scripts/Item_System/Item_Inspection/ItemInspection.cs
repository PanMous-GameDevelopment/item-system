using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspection : MonoBehaviour
{
    private bool isInspectionActive = false;
    private Vector3 itemOriginalPosition;
    private Quaternion itemOriginalRotation;
    public Camera mainCamera;   
    public float interactionDistance = 2f;

    public GameObject player; // The game object with the script to be disabled
    public MonoBehaviour firstPersonController; // The script to be disabled

    public GameObject itemObject;

    public GameObject InspectionUI;

    // This function is called when the player clicks on the object
    private void OnMouseDown()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance)) // Cast raycast.
        {
            if (!isInspectionActive)
            {
                firstPersonController.enabled = false;
                InspectionUI.SetActive(true);
                // Store the original position and rotation of the object
                itemOriginalPosition = transform.position;
                itemOriginalRotation = transform.rotation;

                // Move the object to the center of the screen
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, Camera.main.nearClipPlane + 0.3f));

                // Enable inspection mode
                isInspectionActive = true;
            }
        }
    }

    private void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
    }

    // This function is called every frame
    private void Update()
    {
        if (isInspectionActive)
        {
            // Rotate the object based on the mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.up, mouseX * 5f, Space.World);
            transform.Rotate(Vector3.right, -mouseY * 5f, Space.Self);

            if (Input.GetKeyDown(KeyCode.E))
            {
                itemObject.GetComponent<Item>().GetItem();
                firstPersonController.enabled = true;
                transform.position = itemOriginalPosition;
                transform.rotation = itemOriginalRotation;
                isInspectionActive = false;
                InspectionUI.SetActive(false);
                itemObject.SetActive(false);
            }

            // If the player presses the Escape key, exit inspection mode and return the object to its original position
            if (Input.GetMouseButtonDown(1))
            {
                firstPersonController.enabled = true;
                InspectionUI.SetActive(false);
                transform.position = itemOriginalPosition;
                transform.rotation = itemOriginalRotation;
                isInspectionActive = false;
            }
        }
    }
}
