using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component rotates the player horizontally and the camera vertically based on mouse movement.
 */
public class InputRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.1f;

    [Tooltip("Rotate the player object horizontally with the mouse X-axis movement?")]
    [SerializeField] bool horizontalRotation = true;

    [Tooltip("Rotate the camera object vertically with the mouse Y-axis movement?")]
    [SerializeField] bool verticalRotation = true;

    [SerializeField] float minVerticalRotation = -45f;
    [SerializeField] float maxVerticalRotation = 45f;

    [SerializeField] InputAction lookLocation = new InputAction(type: InputActionType.Value);

    [SerializeField] Transform playerBody; // Reference to the Player GameObject
    [SerializeField] Transform cameraTransform; // Reference to the Camera GameObject

    void OnEnable()
    {
        lookLocation.Enable();
    }

    void OnDisable()
    {
        lookLocation.Disable();
    }

    void OnValidate()
    {
        if (lookLocation.bindings.Count == 0)
        {
            lookLocation.AddBinding("<Mouse>/delta");
        }
    }

    void Update()
    {
        Vector2 mouseDelta = lookLocation.ReadValue<Vector2>();

        // Horizontal rotation (applied to the Player object)
        if (horizontalRotation && playerBody != null)
        {
            float horizontalRotationAmount = mouseDelta.x * rotationSpeed;
            playerBody.Rotate(Vector3.up, horizontalRotationAmount, Space.World); // Rotate around global Y-axis
        }

        // Vertical rotation (applied to the Camera only)
        if (verticalRotation && cameraTransform != null)
        {
            float verticalRotationAmount = -mouseDelta.y * rotationSpeed; // Invert for correct direction
            float currentRotationX = cameraTransform.localEulerAngles.x;

            if (currentRotationX > 180f)
            {
                currentRotationX -= 360f;
            }

            float newRotationX = Mathf.Clamp(currentRotationX + verticalRotationAmount, minVerticalRotation, maxVerticalRotation);
            cameraTransform.localEulerAngles = new Vector3(newRotationX, 0, 0);
        }
    }
}
