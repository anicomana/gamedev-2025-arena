using TMPro;
using UnityEngine;

public class ScoreGoal : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            score++;
            Debug.Log("Goal #" + score + " scored in " + gameObject.name);
            UpdateScoreText();
            collision.gameObject.GetComponent<RespawnIfNeeded>().Respawn();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
