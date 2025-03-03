using UnityEngine;

namespace HJ
{
    public class HJ_GrenadeThrow : MonoBehaviour
    {
        public GameObject grenadePrefab;
        public Camera playerCamera;
        public float throwForce = 10f;

        private void Awake()
        {
            if (!playerCamera)
            {
                Debug.LogError("Assign Camera in inspector");
            }
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire2") && grenadePrefab != null)
            {
                ThrowGrenade();
            }
        }

        void ThrowGrenade()
        {
            GameObject grenade = Instantiate(grenadePrefab, playerCamera.transform.position + playerCamera.transform.forward, Quaternion.identity);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange);
            }
        }
    }
}