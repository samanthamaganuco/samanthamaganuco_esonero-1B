using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float moveSpeed = 4f;        // più lento
    public float fastSpeed = 10f;       // velocità quando premi Shift
    public float lookSpeed = 0.8f;      // sensibilità mouse più bassa
    public float zoomSpeed = 3f;        // zoom più controllato

    float rotX;
    float rotY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ROTAZIONE PRECISA
        rotX += Input.GetAxis("Mouse X") * lookSpeed;
        rotY -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotY = Mathf.Clamp(rotY, -80f, 80f);
        transform.rotation = Quaternion.Euler(rotY, rotX, 0);

        // VELOCITÀ NORMALE O BOOST
        float speed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : moveSpeed;

        // MOVIMENTO WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        transform.position += move * speed * Time.deltaTime;

        // MOVIMENTO SU/GIÙ
        if (Input.GetKey(KeyCode.E))
            transform.position += Vector3.up * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            transform.position -= Vector3.up * speed * Time.deltaTime;

        // ZOOM CON ROTELLINA
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * zoomSpeed;
    }
}