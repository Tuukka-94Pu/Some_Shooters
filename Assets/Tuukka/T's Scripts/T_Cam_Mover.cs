using UnityEngine;

public class T_Cam_Mover : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;

    private Transform playerBody;

    private float xRotation = 0.0f;

    private void Start()

    {

        playerBody = transform.parent;

        Cursor.lockState = CursorLockMode.Locked; // lukitse kursori keskelle ruutua

    }

    private void Update()

    {

        RotateCamera();

    }

    private void RotateCamera()

    {

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // niin ett� kamera ei py�ri yl�salaisin

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

    }
}
