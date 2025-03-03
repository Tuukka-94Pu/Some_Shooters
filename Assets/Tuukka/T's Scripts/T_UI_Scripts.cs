using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using static Unity.VisualScripting.Member;

public class T_UI_Scripts : MonoBehaviour
{
    public TMP_Text scoreNumber;
   // public TMP_Text ammoNumber;
    public int scoreValue;
   // private int ammo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
     

    }

    // Update is called once per frame
    void Update()
    {
        GameObject source = GameObject.Find("bean");
        scoreValue = source.GetComponent<T_CollectblePickup>().score;
        scoreNumber.text = scoreValue.ToString();
    }
}
