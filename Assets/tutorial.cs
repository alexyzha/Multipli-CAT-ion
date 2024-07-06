using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    bool clicked = false;
    public Sprite question;
    public Sprite x;
    public GameObject forward;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    List<GameObject> pages =  new List<GameObject>();
    public dragAll drag;
    public Button settings;

    GameObject[] titles;
    int page = 1;
    public GameObject back;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject tut in GameObject.FindGameObjectsWithTag("tutorial"))
            tut.SetActive(false);
        titles = GameObject.FindGameObjectsWithTag("title");
        page = 1;
        pages.Add(one);
        pages.Add(two);
        pages.Add(three);
        pages.Add(four);
        pages.Add(five);
        pages.Add(six);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click() {
        if (clicked) {
            clicked = false;
            foreach (GameObject tut in GameObject.FindGameObjectsWithTag("tutorial")) {
                tut.SetActive(false);
            }
            GetComponent<UnityEngine.UI.Image>().sprite = question;
            foreach (GameObject title in titles) {
                title.SetActive(true);
            }
            if (drag)
                drag.setEnable(true);
            if (settings)
                settings.interactable = true;
        } else {
            clicked = true;
            forward.SetActive(true);
            one.SetActive(true);
            GetComponent<UnityEngine.UI.Image>().sprite = x;
            foreach (GameObject ob in titles) {
                ob.SetActive(false);
            }
            page = 1;
            if (drag)
                drag.setEnable(false);
            if (settings)
                settings.interactable = false;
        }
    }

    public void next() {
        page++;
        if (page == 6)
            forward.SetActive(false);
        if (page == 2)
            back.SetActive(true);
        pages[page-1].SetActive(true);
        pages[page-2].SetActive(false);
    }

    public void prev() {
        page--;
        if (page == 5)
            forward.SetActive(true);
        if (page == 1)
            back.SetActive(false);
        pages[page-1].SetActive(true);
        pages[page].SetActive(false);
    }
}
