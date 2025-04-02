using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class NR_UnlockManager : MonoBehaviour
{
    public Button swordButton;
    public Button spearButton;

    public Button pebbleButton;
    public Button fireballButton;

    public GameObject swordText;
    public GameObject spearText;

    public GameObject pebbleText;
    public GameObject fireballText;

    public bool swordUnlocked = false;
    public bool spearUnlocked = false;

    public bool pebbleUnlocked = false;
    public bool fireballUnlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (swordUnlocked == false)
        {
            swordButton.interactable = false;
            swordText.SetActive(false);
        }
        else if (swordUnlocked == true)
        {
            swordButton.interactable = true;
            swordText.SetActive(true);
        }

        if (spearUnlocked == false)
        {
            spearButton.interactable = false;
            spearText.SetActive(false);
        }
        else if (spearUnlocked == true)
        {
            spearButton.interactable = true;
            spearText.SetActive(true);
        }

        if (pebbleUnlocked == false)
        {
            pebbleButton.interactable = false;
            pebbleText.SetActive(false);
        }
        else if (pebbleUnlocked == true)
        {
            pebbleButton.interactable = true;
            pebbleText.SetActive(true);
        }

        if (fireballUnlocked == false)
        {
            fireballButton.interactable = false;
            fireballText.SetActive(false);
        }
        else if (fireballUnlocked == true)
        {
            fireballButton.interactable = true;
            fireballText.SetActive(true);
        }
    }

    public void UnlockWeapon()
    {
        
    }
}
