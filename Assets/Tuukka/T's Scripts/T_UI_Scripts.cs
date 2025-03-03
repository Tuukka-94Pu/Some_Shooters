using UnityEngine;
using TMPro;


public class T_UI_Scripts : MonoBehaviour
{
    public TMP_Text scoreNumber;
    public TMP_Text ammoNumber;
    private int scoreValue;
    private int ammo;

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
        scoreNumber.text = scoreValue.ToString();
        ammoNumber.text = ammo.ToString();
    }
}
