using Unity.VisualScripting;
using UnityEngine;

public class click : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float zCoordinate;

    void OnMouseDown()
    {
        // Store the object's z position relative to the camera
        zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Calculate the offset between the object's position and the mouse position
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        // Update the object's position to the mouse's world position plus the stored offset
        transform.position = GetMouseWorldPos() + mouseOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // Get the mouse position from Input
        Vector3 mousePoint = Input.mousePosition;

        // Set the z coordinate to the distance we stored earlier
        mousePoint.z = zCoordinate;

        // Convert the screen point to a world point
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
