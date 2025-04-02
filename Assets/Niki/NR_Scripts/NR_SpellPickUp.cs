using UnityEngine;
using static NR_PickUp;

public class NR_SpellPickUp : MonoBehaviour, IPickUpable
{

    public int index;
    public GameObject spell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        NR_UnlockManager unlockManager = GameObject.FindWithTag("Player").GetComponent<NR_UnlockManager>();

        if (index == 1)
        {
            if (!unlockManager.pebbleUnlocked)
            {
                NR_PlayerStats playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();

                playerStats.SelectSpell(spell);
            }

            unlockManager.pebbleUnlocked = true;
        }
        if (index == 2)
        {
            if (!unlockManager.fireballUnlocked)
            {
                NR_PlayerStats playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();

                playerStats.SelectSpell(spell);
            }

            unlockManager.fireballUnlocked = true;
        }

        Destroy(gameObject);
    }

    public interface IPickUpable
    {
        void PickUp();
    }
}
