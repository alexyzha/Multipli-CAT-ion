using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunGame : MonoBehaviour
{
    public GameObject score;
    public GameObject cardPrefab;
    public GameObject prefabSolution;
    private int randNum;
    public const string ColPass = "colpass";

    // Update is called once per frame
    void Update()
    {
        
    }
    void Start() {
        //SceneManager.LoadScene (sceneName:"menu");
        generateNew();
        randomNumber();
    }

    public void generateNew () {
        Vector3[] positions = {new Vector3((float) 0.6, (float) 3.7, 0), new Vector3((float) 3.4, (float) 3.7, 0), 
            new Vector3((float) 6.13, (float) 3.7, 0), new Vector3((float) 0.6, (float) 1.55, 0), new Vector3((float) 3.4, (float) 1.55, 0), 
            new Vector3((float) 6.13, (float) 1.55, 0), new Vector3((float) 0.6, (float) -0.6, 0), new Vector3((float) 3.4, (float) -0.6, 0), 
            new Vector3((float) 6.13, (float) -0.6, 0), new Vector3((float) 0.6, (float) -2.75, 0), new Vector3((float) 3.4, (float) -2.75, 0), 
            new Vector3((float) 6.13, (float) -2.75, 0)};
        for (int i = 1; i <=12; i++) {
            /*
            string[] colors = {"gray", "orange", "white"};
            var randCol = new System.Random();
            int index = randCol.Next(colors.Length);
            string folder = colors[index];*/
            string folderpath = "";
            int col = PlayerPrefs.GetInt(ColPass);
            if (col == 0)
                folderpath = "white/" + i.ToString();
            if (col == 1)
                folderpath = "gray/" + i.ToString();
            if (col == 2)
                folderpath = "orange/" + i.ToString();
            if (col == 3)
                folderpath = "glass/" + i.ToString();

            GameObject instance = Instantiate(
                                        cardPrefab, 
                                        positions[i-1], 
                                        Quaternion.identity
                                    );

            Sprite sprite = Resources.Load<Sprite>(folderpath);
            instance.GetComponent<SpriteRenderer>().sprite = sprite;
            instance.name = i.ToString();
            //cardPrefab.GetComponent<SpriteRenderer>().enabled = true;
            instance.GetComponent<SpriteRenderer>().enabled = true;
            instance.layer = 9;
            instance.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Default");
        }

    }

    public void randomNumber () {
        int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 
            18, 20, 21, 22, 24, 25, 27, 28, 30, 32, 33, 35, 36, 40, 42, 44, 
            45, 48, 49, 50, 54, 55, 60, 63, 64, 66, 70, 72, 77, 80, 81, 88, 
            90, 99, 100, 110, 121, 132, 144};
        var rnd = new System.Random();
        randNum = rnd.Next(1, numbers.Length-1);
        GameObject instance = Instantiate(
                                        prefabSolution, 
                                        new Vector3((float) -4, 0, 0),  
                                        Quaternion.identity
                                    );

            /*
            string[] colors = {"gray", "orange", "white"};
            var randCol = new System.Random();
            int index = randCol.Next(colors.Length);
            string folder = colors[index];*/
            string folderpath = "";
            int col = PlayerPrefs.GetInt(ColPass);
            if (col == 0)
                folderpath = "white/" + numbers[randNum-1].ToString();
            if (col == 1)
                folderpath = "gray/" + numbers[randNum-1].ToString();
            if (col == 2)
                folderpath = "orange/" + numbers[randNum-1].ToString();
            if (col == 3)
                folderpath = "glass/" + numbers[randNum-1].ToString();

            Sprite sprite = Resources.Load<Sprite>(folderpath);
            instance.GetComponent<SpriteRenderer>().sprite = sprite;
            instance.name = numbers[randNum-1].ToString();
            instance.GetComponent<SpriteRenderer>().enabled = true;
    }
}
