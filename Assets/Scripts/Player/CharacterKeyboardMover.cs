using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


/**
 * This component moves a player controlled with a CharacterController using the keyboard.
 */
[RequireComponent(typeof(CharacterController))]
public class CharacterKeyboardMover : MonoBehaviour
{
    [Tooltip("Speed of player keyboard-movement, in meters/second")]
    [SerializeField] float speed = 3.5f;
    [SerializeField] float gravity = 9.81f;

    private CharacterController cc;

    [SerializeField] InputAction moveAction;
    private void OnEnable() { moveAction.Enable(); }
    private void OnDisable() { moveAction.Disable(); }
    void OnValidate()
    {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (moveAction == null)
            moveAction = new InputAction(type: InputActionType.Button);
        if (moveAction.bindings.Count == 0)
            moveAction.AddCompositeBinding("2DVector")
                // WASD keys
                .With("Up", "<Keyboard>/w")
                .With("Down", "<Keyboard>/s")
                .With("Left", "<Keyboard>/a")
                .With("Right", "<Keyboard>/d");
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    Vector3 velocity = new Vector3(0, 0, 0);

    void Update()
    {
        // Read movement input as Vector2
        Vector2 input = moveAction.ReadValue<Vector2>();

        // Convert input to a Vector3 for movement on the XZ plane
        Vector3 movement = new Vector3(input.x, 0, input.y);

        // Transform the movement vector to match the player's orientation
        movement = transform.TransformDirection(movement);

        if (cc.isGrounded)
        {
            // Apply movement input to the velocity
            velocity.x = movement.x * speed;
            velocity.z = movement.z * speed;

            // Reset vertical velocity when grounded
            velocity.y = 0;
        }
        else
        {
            // Apply gravity if the player is not grounded
            velocity.y -= gravity * Time.deltaTime;
        }

        // Apply movement through the CharacterController
        cc.Move(velocity * Time.deltaTime);
    }


}