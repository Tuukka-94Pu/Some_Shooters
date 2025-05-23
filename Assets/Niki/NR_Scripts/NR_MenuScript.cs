using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NR_MenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject UI;
    public GameObject baseMenu;
    public GameObject magicMenu;
    public GameObject equipmentMenu;
    public GameObject weaponMenu;
    public GameObject handSpellMenu;
    
    public bool menuOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && menuOpen == false)
        {
            menu.SetActive(true);
            menuOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && menuOpen == true)
        {
            CloseMenu();
        }

        
    }


    public void OpenWantedMenu(GameObject menu)
    {
        menu.SetActive(true);
        baseMenu.SetActive(false);

        
    }

    public void BackToBaseMenu()
    {
        baseMenu.SetActive(true);
        magicMenu.SetActive(false);
        equipmentMenu.SetActive(false);
    }

    public void OpenEquipmentSubMenu(GameObject menu)
    {
        menu.SetActive(true);
        equipmentMenu.SetActive(false);
    }

    public void BackToEquipmentMenu()
    {
        equipmentMenu.SetActive(true);
        weaponMenu.SetActive(false);
        handSpellMenu.SetActive(false);
    }

    
    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        menuOpen = false;

        BackToEquipmentMenu();
        BackToBaseMenu();

        Cursor.lockState = CursorLockMode.Locked;
    }
}