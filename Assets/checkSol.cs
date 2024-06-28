using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkSol : Reset
{
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "main") {
            Vector3 pos = new Vector3((float) -3.3, (float) 2.6, 0);
            Collider2D hit = Physics2D.OverlapCircle(pos, 0.2f);
            if (GameObject.FindGameObjectsWithTag("solution").Length > 1) {
                GameObject cat = GameObject.FindGameObjectsWithTag("solution")[1];
                if (hit && Input.GetMouseButtonUp(0) && int.Parse(hit.name) == int.Parse(cat.name)) {
                    Destroy(cat);
                    score.SendMessage("nextLevel");
                    resetLevel();
                    randomNumber();
                }
            }
        }
    }
}
