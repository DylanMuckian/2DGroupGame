using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for rotating a GameObject when the mouse is clicked and dragged.
/// The GameObject rotates around the Z axis based on the mouse's movement.
/// The rotation speed can be adjusted using the `rotationSpeed` variable.
/// </summary>

public class MouseRotateObject : MonoBehaviour
{
    public float rotationSpeed = 20.0f;
    private Vector3 lastMousePosition;

    void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
    }

    
    void OnMouseDrag()
    {
        // Calculate the difference in mouse position
        Vector3 delta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;

        // Rotate the GameObject around the Z axis
        float rotationZ = delta.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotationZ);
    }
}
