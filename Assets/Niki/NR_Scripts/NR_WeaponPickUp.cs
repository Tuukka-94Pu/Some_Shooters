using UnityEngine;
using static NR_PickUp;

public class NR_WeaponPickUp : MonoBehaviour, IPickUpable
{
    public int index;
    public GameObject weapon;

    public void PickUp()
    {
        NR_UnlockManager unlockManager = GameObject.FindWithTag("Player").GetComponent<NR_UnlockManager>();

        if (index == 1)
        {
            if (!unlockManager.swordUnlocked)
            {
                NR_PlayerStats playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();

                playerStats.SelectWeapon(weapon);
            }

            unlockManager.swordUnlocked = true;
        }
        if (index == 2)
        {
            if (!unlockManager.spearUnlocked)
            {
                NR_PlayerStats playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();

                playerStats.SelectWeapon(weapon);
            }

            unlockManager.spearUnlocked = true;
        }

        Destroy(gameObject);
    }

    public interface IPickUpable
    {
        void PickUp();
    }
}
