using UnityEngine;

public class NR_PickUp : MonoBehaviour
{
    public float pickUpRange = 2f;
    public Camera playerCamera;
    public LayerMask pickUpLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange, pickUpLayer))
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * pickUpRange, Color.red, 2.0f);

            IPickUpable pickUpable = hit.transform.GetComponent<IPickUpable>();
            if (pickUpable != null)
            {
                pickUpable.PickUp();
            }
        }
    }

    public interface IPickUpable
    {
        void PickUp();
    }
}
