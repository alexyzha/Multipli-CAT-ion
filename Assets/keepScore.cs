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
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + totalScore.ToString();
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
            totalScore++;
        }

        //time
        if (startGame.Instance.timed) {
            if (totalScore < 10)
                GameObject.Find("timer").GetComponent<timer>().setTime(30);
            else if (totalScore < 20)
                GameObject.Find("timer").GetComponent<timer>().setTime(20);
            else if (totalScore < 30)
                GameObject.Find("timer").GetComponent<timer>().setTime(10);
            else
                GameObject.Find("timer").GetComponent<timer>().setTime(5);
        }

        if (totalScore == 10 || totalScore == 25 || totalScore % 50 == 0) {
            GameObject.Find("confetti").transform.position = new Vector3(0, 12, 0);
            audioSource.Play();
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
