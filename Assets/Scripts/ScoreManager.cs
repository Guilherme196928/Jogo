using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  
    private float score = 0f;
    private bool isCounting = true;

    void Update()
    {
        if (isCounting)
        {
            score += Time.deltaTime;
            scoreText.text = "Pontuação: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void StopScore()
    {
        isCounting = false;
    }

    public void ResetScore()
    {
        score = 0f;
        isCounting = true;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }
}
