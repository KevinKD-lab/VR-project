using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GazeInteraction : MonoBehaviour
{
    public Camera vrCamera; // Reference to the VR camera
    public TextMeshProUGUI infoText; // Reference to the TMP Text element

    public float maxDistance = 10f; // Maximum distance to check for objects
    public LayerMask layerMask; // Layer mask to filter objects

    // Update is called once per frame
    void Update()
    {
        // Create a ray from the center of the screen
        Ray ray = vrCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        // Create a RaycastHit variable to store information about the object hit by the raycast
        RaycastHit hit;

        // Check if the raycast hits an object within the specified maximum distance and using the specified layer mask
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            // Check if the hit object has a tag or other identifier to indicate it should trigger UI display
            if (hit.collider.CompareTag("Painting"))
            {
               // Display TMP Text and position it in front of the VR camera
                infoText.gameObject.SetActive(true);
                infoText.transform.position = vrCamera.transform.position + vrCamera.transform.forward * 2f; // Adjust the position as needed

                // Ensure the TMP Text faces the camera by rotating it
                Vector3 lookPos = vrCamera.transform.position - infoText.transform.position;
                lookPos.x = -lookPos.x; // Flip the rotation on the X-axis
                lookPos.y = -lookPos.y; // Optionally, flip the rotation on the Y-axis if needed
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                rotation *= Quaternion.Euler(180f, 0f, 0f); // Rotate the text by 180 degrees on the X-axis
                infoText.transform.rotation = rotation;
            }
        }
        else
        {
            // If no object is hit, hide the TMP Text
            infoText.gameObject.SetActive(false);
        }
    }
}
