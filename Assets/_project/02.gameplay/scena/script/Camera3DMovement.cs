using UnityEngine;

public class Camera3DMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float verticalSpeed = 2f;
    public float rotationSpeed = 60f;
    public float zoomSpeed = 30f;

    float verticalRotation = 0f;   // memorizza la rotazione verticale

    void Update()
    {
        // --- MOVIMENTO ---
        float forward = Input.GetAxis("Vertical");     // W / S
        float sideways = Input.GetAxis("Horizontal");  // A / D

        float upDown = 0f;
        if (Input.GetKey(KeyCode.E)) upDown = 1f;
        if (Input.GetKey(KeyCode.Q)) upDown = -1f;

        Vector3 horizontalMove =
            transform.forward * forward * moveSpeed +
            transform.right * sideways * moveSpeed;

        Vector3 verticalMove = Vector3.up * upDown * verticalSpeed;

        transform.position += (horizontalMove + verticalMove) * Time.deltaTime;

        // --- ROTAZIONE ORIZZONTALE (sinistra/destra) ---
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // --- ROTAZIONE VERTICALE (su/giù) con LIMITE ---
        float rotInput = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) rotInput = -rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) rotInput = rotationSpeed * Time.deltaTime;

        verticalRotation += rotInput;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0f);

        // --- ZOOM ---
        if (Input.GetKey(KeyCode.Z))
            transform.position += transform.forward * zoomSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.X))
            transform.position -= transform.forward * zoomSpeed * Time.deltaTime;
    }
}