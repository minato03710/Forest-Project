using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [Header("Camera Pivot")]
    public Transform cameraPivot;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;

    [Header("Vertical Limits")]
    public float minVerticalAngle = -30f;
    public float maxVerticalAngle = 30f;

    [Header("Horizontal Limits")]
    public float minHorizontalAngle = -80f;
    public float maxHorizontalAngle = 80f;

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    void Update()
    {
        if (Mouse.current == null)
            return;

        // Get mouse movement
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x;
        float mouseY = mouseDelta.y;

        //Rotate left and right

        horizontalRotation +=
            mouseX * mouseSensitivity * Time.deltaTime;

        horizontalRotation = Mathf.Clamp(
            horizontalRotation,
            minHorizontalAngle,
            maxHorizontalAngle
        );

        cameraPivot.localRotation =
            Quaternion.Euler(
                0f,
                horizontalRotation,
                0f
            );


        // Rotate up and down

        verticalRotation -=
            mouseY * mouseSensitivity * Time.deltaTime;

        verticalRotation = Mathf.Clamp(
            verticalRotation,
            minVerticalAngle,
            maxVerticalAngle
        );

        transform.localRotation =
            Quaternion.Euler(
                verticalRotation,
                0f,
                0f
            );
    }
}