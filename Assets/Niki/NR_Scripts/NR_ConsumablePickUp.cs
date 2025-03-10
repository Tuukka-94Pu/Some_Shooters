using UnityEngine;
using static NR_PickUp;

public class NR_ConsumablePickUp : MonoBehaviour, IPickUpable
{

    public void PickUp()
    {
        NR_PlayerStats playerStats = GameObject.Find("Player").GetComponent<NR_PlayerStats>();
        playerStats.healingConsumables += 1;
        playerStats.healingConsumableAmmount.text = "" + playerStats.healingConsumables;
        Destroy(gameObject);
    }
}
