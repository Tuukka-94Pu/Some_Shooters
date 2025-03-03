using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class T_UI_Scripts : MonoBehaviour
{
    public TMP_Text scoreNumber;
   // public TMP_Text ammoNumber;
    public int scoreValue;
   // private int ammo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject source = GameObject.Find("bean");
        scoreValue = source.GetComponent<T_CollectblePickup>().score;

    }

    // Update is called once per frame
    void Update()
    {
        scoreNumber.text = scoreValue.ToString();
    }
}
