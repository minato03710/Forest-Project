using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Camera Rotation")]
    public float sensitivity = 100f;

    [Header("Vertical Limits")]
    public float minPitch = -30f;
    public float maxPitch = 30f;

    [Header("Horizontal Limits")]
    public float minYaw = -70f;
    public float maxYaw = 70f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        yaw = currentRotation.y;
        pitch = currentRotation.x;

        if (pitch > 180f)
        {
            pitch -= 360f;
        }
    }

    void Update()
    {
        // Gallery 打开时不要控制 Camera
        if (Time.timeScale == 0f)
            return;

        // 只有按住左键的时候才能移动 Camera
        if (Mouse.current != null &&
            Mouse.current.leftButton.isPressed)
        {
            Vector2 mouseDelta =
                Mouse.current.delta.ReadValue();

            yaw += mouseDelta.x * sensitivity * Time.deltaTime;
            pitch -= mouseDelta.y * sensitivity * Time.deltaTime;

            yaw = Mathf.Clamp(
                yaw,
                minYaw,
                maxYaw
            );

            pitch = Mathf.Clamp(
                pitch,
                minPitch,
                maxPitch
            );

            transform.localRotation =
                Quaternion.Euler(
                    pitch,
                    yaw,
                    0f
                );
        }
    }
}