using UnityEngine;
using TMPro;


public class T_UI_Scripts : MonoBehaviour
{
    //All of the varibles


    public TMP_Text scoreNumber;
    public TMP_Text ammoNumber;
    public TMP_Text fragText;
    public TMP_Text typeText;
    public TMP_Text healthtext;
    public GameObject Gameover;


    private int scoreValue;
    private int ammo;
    private int fragAmount;
    private string fragType;
    private int healthAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Get the needed values from source, it being the player object that all the needed scripts are attached to
        GameObject source = GameObject.Find("bean");
        scoreValue = source.GetComponent<T_CollectblePickup>().score;
        ammo = source.GetComponent<T_ShooterScript>().ammoCount;
        fragAmount = source.GetComponent<T_FragOut>().fragCount;
        fragType = source.GetComponent<T_FragOut>().type;
        healthAmount = source.GetComponent<T_PlayerHealth>().playerHP;

        //Turn int into strings to show in TMP
        scoreNumber.text = scoreValue.ToString();
        ammoNumber.text = ammo.ToString();
        fragText.text = fragAmount.ToString();
        healthtext.text = healthAmount.ToString();
        

        //Ammo count text color changes
        if (ammo == 0)
        {
            ammoNumber.color = new Color(255, 0, 0);
        }
        else
        {
            ammoNumber.color = new Color(0, 255, 0);
        }
        if(fragAmount == 0)
        {
            fragText.color = new Color(255, 0,0);
        }
        else
        {
            fragText.color = new Color(0,255,0);
        }
        //Grenade type changes
        if(fragType == "Pipe")
        {
            typeText.text = "Timed frags";
        }
        if(fragType == "Remote")
        {
            typeText.text = "Remote bomb";
        }

        //Health text color changes
        if(healthAmount > 50)
        {
            healthtext.color = new Color(0, 255, 0);
        }
        if(healthAmount >= 25 && healthAmount <= 50)
        {
            healthtext.color = new Color(255, 255, 0);
        }
        if (healthAmount < 25)
        {
            healthtext.color = new Color(255 ,0,0);
           
        }
        if(healthAmount <= 0)
        {
            Gameover.SetActive(true);
        }



    }
}
