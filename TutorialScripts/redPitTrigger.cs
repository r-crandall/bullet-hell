using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redPitTrigger : MonoBehaviour
{

    public int neutralBallScore = 0;
    public int redBallScore = 0;
    public int totalBallScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NeutralBall")
        {
            neutralBallScore++;
            totalBallScore++;
            print("Overall: " + totalBallScore + "Neutral: " + neutralBallScore);
        }
        if(other.gameObject.tag == "RedBall")
        {
            redBallScore++;
            totalBallScore++;
            print("Overall: " + totalBallScore + "Red: " + redBallScore);
        }
    }
}
