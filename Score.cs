using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private int totalScore = 0;

    public void AddScore(int amount)
    {
        totalScore += amount;
        scoreText.text = totalScore.ToString();
    }
}
