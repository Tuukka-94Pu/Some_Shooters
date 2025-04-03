using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class T_menuScript : MonoBehaviour
{
    public Button backtoMenu;
    public Button resetMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //This has to be a seperate script from the main menu script to avoid NullReferanceException Issues
      
        Button toMenubutton = backtoMenu.GetComponent<Button>();
        Button resetMapButton = resetMap.GetComponent<Button>();
        toMenubutton.onClick.AddListener(Click);
        resetMapButton.onClick.AddListener(ResetMap);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        SceneManager.LoadScene("T's Shooters menu");
    }
    public void ResetMap()
    {
        //So if somehow you die , pressing restart will reset the scene, including score, ammo, health , enemies.
        SceneManager.LoadScene("T's shooter");
    }
}