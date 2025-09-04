using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody))]
public class NewMonoBehaviourScript : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    //private Rigidbody rb;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Assuming you have an InputActionAsset named "InputActions" in your project
        var inputActions = new InputActionAsset();

        // Create Move action (Vector2, WASD)
        moveAction = new InputAction("Move", InputActionType.Value, "<Keyboard>/wasd", null, null, "Vector2");
        moveAction.Enable();

        // Create Jump action (Button, Space)
        jumpAction = new InputAction("Jump", InputActionType.Button, "<Keyboard>/space");
        jumpAction.Enable();
    }
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue != Vector2.zero)
        {
            Debug.Log($"Move: {moveValue}");
            Vector3 move = new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }

        if (jumpAction.triggered)
        {
        //    Debug.Log("Jump");
        //    if (jumpAction.triggered)
        //    {
        //        Debug.Log("Jump");
        //        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f) // Only jump if nearly grounded
        //        {
        //            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //        }
        //    }
        }
    }
}
