using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keepScore : MonoBehaviour
{
    int totalScore = 0;
    int merges = 0;
    [SerializeField] 
        private TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + totalScore.ToString();
        //Debug.Log(totalScore);
        
    }

    public void incrementMerge() {
        merges++;
    }
    public void resetForLevel() {
        merges = 0;
    }
    public void nextLevel() {
        if (merges == 1) {
            totalScore++;
        }
    }

    public int getScore() {
        return totalScore;
    }

    public void highCompare() {
        //loading high score
        int loaded = GameObject.Find("GameObject").GetComponent<highScore>().loadScore();
        int thisRun = getScore();
        //comparing hs
        if(thisRun > loaded) {
            //save hs
            GameObject.Find("GameObject").GetComponent<highScore>().saveScore(thisRun);
        }
    }

}
