using UnityEngine;

public class NR_MenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject UI;

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
            menu.SetActive(false);
            menuOpen = false;
        }
    }
}
