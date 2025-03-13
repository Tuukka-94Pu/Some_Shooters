using UnityEngine;
using static NR_PickUp;

public class NR_WeaponPickUp : MonoBehaviour, IPickUpable
{
    public int index;
    

    public void PickUp()
    {
        NR_UnlockManager unlockManager = GameObject.FindWithTag("Player").GetComponent<NR_UnlockManager>();


        Destroy(gameObject);
    }
}
