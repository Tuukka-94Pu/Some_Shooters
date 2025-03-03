using UnityEngine;
using TMPro;


public class T_CollectblePickup : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            score++;
            scoreText.text =  score.ToString();
            Destroy(other.gameObject);
            
        }
    }
}
