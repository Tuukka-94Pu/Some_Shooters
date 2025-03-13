using UnityEngine;
using static NR_PickUp;

public class NR_ManaConsumable : MonoBehaviour, IPickUpable
{
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
        NR_PlayerStats playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();
        playerStats.manaConsumables += 1;
        playerStats.manaConsumableAmmount.text = "" + playerStats.manaConsumables;
        Destroy(gameObject);
    }
}
