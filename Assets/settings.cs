using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class settings : MonoBehaviour
{
    bool clicked = false;
    public Sprite gear;
    public Sprite x;
    public GameObject gray;
    public GameObject orang;
    public GameObject white;
    public GameObject clear;
    public GameObject wbox;
    public GameObject gbox;
    public GameObject obox;
    public GameObject cbox;
    public GameObject overlay;
    public TMP_Text grayText;
    public TMP_Text orangeText;
    public TMP_Text clearText;
    public dragAll drag;
    public TMP_InputField inputfield;  
    public GameObject inputObj;
    public Button question;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject set in GameObject.FindGameObjectsWithTag("settings"))
            set.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click() {
        if (clicked) {
            clicked = false;
            foreach (GameObject set in GameObject.FindGameObjectsWithTag("settings")) {
                set.SetActive(false);
            }
            grayText.text = "";
            orangeText.text = "";
            clearText.text = "";
            GetComponent<UnityEngine.UI.Image>().sprite = gear;
            if (drag)
                drag.setEnable(true);
            question.interactable = true;
        } else {
            int score = PlayerPrefs.GetInt("TScore");
            int color = PlayerPrefs.GetInt("colpass");
            clicked = true;
            question.interactable = false;
            overlay.SetActive(true);
            white.SetActive(true);
            inputObj.SetActive(true);
            if (score >= 10) {
                gray.SetActive(true);
                grayText.text = "gray";
            } else {
                grayText.text = "****";
            }
            if (score >= 50) {
                orang.SetActive(true);
                orangeText.text = "xena";
            } else {
                orangeText.text = "****";
            }
            if (score >= 100) {
                clear.SetActive(true);
                clearText.text = "cler";
            } else {
                clearText.text = "****";
            }
            switch (color) {
                case 0:
                    wbox.SetActive(true);
                break;
                case 1:
                    gbox.SetActive(true);
                break;
                case 2:
                    obox.SetActive(true);
                break;
                case 3:
                    cbox.SetActive(true);
                break;
            }
            GetComponent<UnityEngine.UI.Image>().sprite = x;
            if (drag)
                drag.setEnable(false);
        }
    }

    public void setCol(int col) {
        PlayerPrefs.SetInt("colpass", col);
        wbox.SetActive(false);
        gbox.SetActive(false);
        obox.SetActive(false);
        cbox.SetActive(false);
        switch (col) {
            case 0:
                wbox.SetActive(true);
            break;
            case 1:
                gbox.SetActive(true);
            break;
            case 2:
                obox.SetActive(true);
            break;
            case 3:
                cbox.SetActive(true);
            break;
        }
    }

    public void CheckInput() {
        switch (inputfield.text)     
        {
            case "gray":
            case "GRAY":
                if (PlayerPrefs.GetInt("TScore") < 10) {
                    int newScore = PlayerPrefs.GetInt("TScore") + 10;
                    PlayerPrefs.SetInt("TScore", newScore);
                    Click();
                    Click();
                    PlayerPrefs.Save();
                }
            break;
            case "xena":
            case "XENA":
                if (PlayerPrefs.GetInt("TScore") < 50) {
                    int newScore = PlayerPrefs.GetInt("TScore") + 50;
                    PlayerPrefs.SetInt("TScore", newScore);
                    Click();
                    Click();
                    PlayerPrefs.Save();
                }
            break;
            case "cler":
            case "CLER":
                if (PlayerPrefs.GetInt("TScore") < 100) {
                    int newScore = PlayerPrefs.GetInt("TScore") + 100;
                    PlayerPrefs.SetInt("TScore", newScore);
                    Click();
                    Click();
                    PlayerPrefs.Save();
                }
            break;
        }
    }
}
