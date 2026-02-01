using Unity.VisualScripting;
using UnityEngine;

public class spawn_objects : MonoBehaviour
{

    // A public variable to hold the prefab you want to instantiate.
    public GameObject objectPrefab;
    // Reference to the main camera, ensure your camera is tagged as "MainCamera".
    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the main camera reference once to optimize performance.
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found! Please tag your camera as 'MainCamera'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button (0) is clicked down this frame.
        if (Input.GetMouseButtonDown(0))
        {
            // Call a function to handle the spawning logic.
            SpawnObjectAtMousePosition();
        }
    }

    void SpawnObjectAtMousePosition()
    {
        // Create a ray from the camera through the mouse position.
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast. If it hits a collider, instantiate the object at that point.
        if (Physics.Raycast(ray, out hit))
        {
            // Instantiate the prefab at the hit point with no rotation.
            Instantiate(objectPrefab, hit.point, Quaternion.identity);
        }
    }
}
