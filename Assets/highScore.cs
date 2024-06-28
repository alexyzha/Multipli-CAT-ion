using UnityEngine;

public class highScore : MonoBehaviour
{

    public const string scorePass = "HScore";

    public void saveScore(int score) {
        PlayerPrefs.SetInt(scorePass, score);
        PlayerPrefs.Save();
    }

    public int loadScore() {
        return(PlayerPrefs.GetInt(scorePass));
    }

}