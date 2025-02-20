using UnityEngine;
using TMPro;
public class T_CoinStuff : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
        scoreText.text = "Score: " + score;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "bean")
        {
            score++;
           
            Destroy(gameObject);
        }
    }
}
