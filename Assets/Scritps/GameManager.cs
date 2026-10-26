using RTLTMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int score = 0;
    public int highScore = 0;

    public RTLTextMeshPro ScoreTXT, HighScoreTXT, EndGameScoreTXT, EndGameHighScoreTXT;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    private void Start()
    {
        highScore =  PlayerPrefs.GetInt("highScore", 0);
        HighScoreTXT.text = "رکورد: " + score;
        ScoreTXT.text = "امتیاز: " + score;

    }

    public void AddScore()
    {
        score += 1;
        ScoreTXT.text = "امتیاز: " + score;

        if (score >= highScore)
        {
            highScore = score;
            HighScoreTXT.text = "رکورد: " + score;
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("highScore",highScore);
        EndGameScoreTXT.text = "امتیاز: " + score;
        EndGameHighScoreTXT.text = "رکورد: " + score;
    }
}
