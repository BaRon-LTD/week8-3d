using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterKeyboardMover : MonoBehaviour {
    [Tooltip("Walking speed of the player, in meters/second.")]
    [SerializeField] float walkSpeed = 10f;

    [Tooltip("Running speed of the player, in meters/second.")]
    [SerializeField] float runSpeed = 18f;

    [Tooltip("Gravity applied to the player, in meters/second^2.")]
    [SerializeField] float gravity = 9.81f;

    [Tooltip("Jump force of the player, in meters/second.")]
    [SerializeField] float jumpForce = 5f;

    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction runAction;
    [SerializeField] InputAction jumpAction;

    private CharacterController cc;
    private Vector3 velocity = Vector3.zero;

    private float groundedBufferTime = 0.1f; // Time buffer for grounded check
    private float groundedTimer = 0f; // Tracks time since last grounded state

    void OnEnable() {
        moveAction.Enable();
        runAction.Enable();
        jumpAction.Enable();
    }

    void OnDisable() {
        moveAction.Disable();
        runAction.Disable();
        jumpAction.Disable();
    }

    void OnValidate() {
        if (moveAction == null)
            moveAction = new InputAction(type: InputActionType.Button);
        if (moveAction.bindings.Count == 0)
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/w")
                .With("Down", "<Keyboard>/s")
                .With("Left", "<Keyboard>/a")
                .With("Right", "<Keyboard>/d");

        if (runAction == null)
            runAction = new InputAction(type: InputActionType.Button);
        if (runAction.bindings.Count == 0)
            runAction.AddBinding("<Keyboard>/leftShift");

        if (jumpAction == null)
            jumpAction = new InputAction(type: InputActionType.Button);
        if (jumpAction.bindings.Count == 0)
            jumpAction.AddBinding("<Keyboard>/space");
    }

    void Start() {
        cc = GetComponent<CharacterController>();
    }

    void Update() {
        // Read movement input.
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y);

        // Transform movement to match the player's orientation.
        movement = transform.TransformDirection(movement);

        // Determine if the player is running.
        bool isRunning = runAction.ReadValue<float>() > 0;
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Check if the player is grounded.
        if (cc.isGrounded) {
            groundedTimer = groundedBufferTime; // Reset the grounded timer when grounded
            velocity.x = movement.x * currentSpeed;
            velocity.z = movement.z * currentSpeed;

            // Check for jump input.
            if (jumpAction.WasPerformedThisFrame()) {
                velocity.y = jumpForce; // Apply jump force.
            } else {
                velocity.y = 0; // Reset vertical velocity when grounded.
            }
        } else {
            // Decrease grounded timer to track how recently the player was grounded.
            groundedTimer -= Time.deltaTime;

            // Allow jumping for a short time after leaving the ground (coyote time).
            if (groundedTimer > 0 && jumpAction.WasPerformedThisFrame()) {
                velocity.y = jumpForce; // Apply jump force during buffer.
            }

            // Apply gravity when not grounded.
            velocity.y -= gravity * Time.deltaTime;
        }

        // Move the player using the CharacterController.
        cc.Move(velocity * Time.deltaTime);
    }
}
