using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text finalText;
    double time = 30.0;
    GameObject[] ends;
    bool ended = false;

    // Start is called before the first frame update
    void Start()
    {
        if (startGame.Instance.timed) {
            timerText.text = "Time: 100";
            GameObject.Find("leaf").SetActive(true);
            GameObject.Find("star").SetActive(false);

        } else {
            timerText.text = "";
            GameObject.Find("leaf").SetActive(false);
            GameObject.Find("star").SetActive(true);

        }
        ends = GameObject.FindGameObjectsWithTag("endScreen");
        foreach (var end in ends)
          {
            end.SetActive(false);
          }
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame.Instance.timed && !ended) {
            if (time > 0) {
                time -= Time.deltaTime;
                timerText.text = "Time: " + ((int) time).ToString();
            } else {
                timerEnded();
                ended = true;
            }
        }
    }

    void timerEnded()
    {
        foreach (var end in ends)
          {
            end.SetActive(true);
          }
        
        GameObject.Find("GameObject").GetComponent<dragAll>().setEnable(false);

        //temp hs to see
        //int highChecker = keepScore.highCompare();
//PLACEHOLDER IF FUNCITON:
        //if(highChecker == 1) {

        GameObject.Find("score").GetComponent<keepScore>().highCompare();
        finalText.text = "Your Score: "
                       + GameObject.Find("score").GetComponent<keepScore>().getScore()
                       + ", High Score: " 
                       + GameObject.Find("GameObject").GetComponent<highScore>().loadScore();
    }

    public void setTime(double t) {
        time = t;
    }
}
