using UnityEngine;
using TMPro;


public class T_UI_Scripts : MonoBehaviour
{
    public TMP_Text scoreNumber;
    public TMP_Text ammoNumber;
    public TMP_Text fragText;
    public TMP_Text typeText;

    private int scoreValue;
    private int ammo;
    private int fragAmount;
    private string fragType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject source = GameObject.Find("bean");
        scoreValue = source.GetComponent<T_CollectblePickup>().score;
        ammo = source.GetComponent<T_ShooterScript>().ammoCount;
        fragAmount = source.GetComponent<T_FragOut>().fragCount;
        fragType = source.GetComponent<T_FragOut>().type;
        scoreNumber.text = scoreValue.ToString();
        ammoNumber.text = ammo.ToString();
        fragText.text = fragAmount.ToString();
        
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
        if(fragType == "Pipe")
        {
            typeText.text = "Timed frags";
        }
        if(fragType == "Remote")
        {
            typeText.text = "Remote bomb";
        }
    }
}
