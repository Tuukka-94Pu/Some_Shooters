using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;

    private Transform playerBody;

    private float xRotation = 0.0f;

    private NR_PlayerStats playerStats;

    private NR_MenuScript menuScript;


    private void Start()
    {
        
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked; // lukitse kursori keskelle ruutua
        playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();
        menuScript = GetComponentInParent<NR_MenuScript>();
    }

    private void Update()
    {
        if (playerStats.dead == false && menuScript.menuOpen == false)
        {
            RotateCamera();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // niin että kamera ei pyöri ylösalaisin

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}