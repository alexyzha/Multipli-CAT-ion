using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public Button endless;
    public Button timer;
    public static startGame Instance; 
    public bool timed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        endless.onClick.AddListener(el);
        timer.onClick.AddListener(tme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void el() {
        SceneManager.LoadScene (sceneName:"main");
    }
    void tme() {
        timed = true;
        el();
    }
}
