using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keepScore : MonoBehaviour
{
    int score = 0;
    int merges = 0;
    [SerializeField] 
        private TMP_Text scoreText;
    private AudioSource audioSource;
    [SerializeField] 
        private TMP_Text totalScoreText;
    [SerializeField] 
        private Sprite gray;
    [SerializeField] 
        private Sprite orange;
    [SerializeField] 
        private Sprite clear;
    [SerializeField] 
        private GameObject unlockCat;
    int totalScore;
    public const string ColPass = "colpass";

    void Start() {
        audioSource = GetComponent<AudioSource>();
        updateTotal();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(totalScore);

        Transform cf = GameObject.Find("confetti").transform;
        Vector3 pos = cf.position;
        for (int i = 0; i < 50; i++) {
            pos.y -= Time.deltaTime * 0.5f;
            cf.position = pos;
        }
    }

    public void incrementMerge() {
        merges++;
    }
    public void resetForLevel() {
        merges = 0;
    }
    public void nextLevel() {
        if (merges == 1) {
            score++;
            int newScore = GameObject.Find("GameObject").GetComponent<highScore>().AddTScore();
            if (newScore == 10)
                PlayerPrefs.SetInt(ColPass, 1);
            if (newScore == 50)
                PlayerPrefs.SetInt(ColPass, 2);
            if (newScore == 100)
                PlayerPrefs.SetInt(ColPass, 3);
        }

        //time
        if (startGame.Instance.timed) {
            if (score < 10)
                GameObject.Find("timer").GetComponent<timer>().setTime(41);
            else if (score < 20)
                GameObject.Find("timer").GetComponent<timer>().setTime(31);
            else if (score < 30)
                GameObject.Find("timer").GetComponent<timer>().setTime(21);
            else if (score < 40)
                GameObject.Find("timer").GetComponent<timer>().setTime(11);
            else
                GameObject.Find("timer").GetComponent<timer>().setTime(6);
        }

        if (score != 0 && (score == 10 || score == 25 || score % 50 == 0)) {
            GameObject.Find("confetti").transform.position = new Vector3(0, 12, 0);
            audioSource.Play();
        }

        updateTotal();
    }

    public int getScore() {
        return score;
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

    public void updateTotal() {
        totalScore = GameObject.Find("GameObject").GetComponent<highScore>().loadTScore();
        scoreText.text = "Score: " + score.ToString();
        if (totalScore < 10) {
            totalScoreText.text = "total score: " + totalScore.ToString() + ", "+ (10 - totalScore).ToString() + " more to unlock";
            unlockCat.GetComponent<SpriteRenderer>().sprite = gray;
        } else if (totalScore < 50) {
            totalScoreText.text = "total score: " + totalScore.ToString() + ", "+ (50 - totalScore).ToString() + " more to unlock";
            unlockCat.GetComponent<SpriteRenderer>().sprite = orange;
        } else if (totalScore < 100) {
            totalScoreText.text = "total score: " + totalScore.ToString() + ", "+ (100 - totalScore).ToString() + " more to unlock";
            unlockCat.GetComponent<SpriteRenderer>().sprite = clear;
        } else {
            totalScoreText.text = "total score: " + totalScore.ToString();
            unlockCat.SetActive(false);
        }
    }
}
