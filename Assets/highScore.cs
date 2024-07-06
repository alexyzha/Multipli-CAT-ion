using UnityEngine;
using UnityEditor;

public class highScore : MonoBehaviour
{
    public const string scorePass = "HScore";
    public const string TPass = "TScore";
    public const string ColPass = "colpass";
    
    public void saveScore(int score) {
        PlayerPrefs.SetInt(scorePass, score);
        PlayerPrefs.Save();
    }
    public int AddTScore() {
        int newScore = PlayerPrefs.GetInt(TPass) + 1;
        PlayerPrefs.SetInt(TPass, newScore);
        PlayerPrefs.Save();
        return newScore;
    }

    public int loadTScore() {
        return(PlayerPrefs.GetInt(TPass));
    }

    public int loadScore() {
        return(PlayerPrefs.GetInt(scorePass));
    }

}