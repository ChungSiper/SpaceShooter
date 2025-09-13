using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private InputAction walkAction;
    private InputAction jumpAction;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        walkAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = walkAction.ReadValue<Vector2>();
        bool jumpInput = jumpAction.IsPressed();
       
        if (moveValue != Vector2.zero)
        {
            Debug.Log($"Move: {moveValue}");
            Vector3 move = new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }

        if (jumpAction.triggered)
        {
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
