using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private Vector3 inputDirection;
    private float yRotation = 0f;
    public Transform playerBody;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Maus einfangen
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxis("Mouse X"); // Horizontal

        // Rotation anpassen
        yRotation += mouseX * mouseSensitivity * Time.deltaTime;
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);

        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        Vector3 moveVelocity = playerBody.TransformDirection(inputDirection) * moveSpeed;
        Vector3 newPosition = rb.position + moveVelocity * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
