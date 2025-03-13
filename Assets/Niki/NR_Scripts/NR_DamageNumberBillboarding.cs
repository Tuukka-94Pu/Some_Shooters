using UnityEngine;

public class NR_DamageNumberBillboarding : MonoBehaviour
{

    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = cam.transform.forward;
    }
}
