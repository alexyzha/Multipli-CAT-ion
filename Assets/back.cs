using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class back : MonoBehaviour
{
    GameObject[] ends;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backBtn() {
        SceneManager.LoadScene (sceneName:"menu");
    }

    public void contBtn() {
        GameObject.Find("GameObject").GetComponent<dragAll>().setEnable(true);
        ends = GameObject.FindGameObjectsWithTag("endScreen");
        foreach (var end in ends)
          {
            end.SetActive(false);
          }        
    }
}
