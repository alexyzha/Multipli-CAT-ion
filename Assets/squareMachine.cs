using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareMachine : MonoBehaviour
{
    public GameObject cardPrefab;
      [SerializeField] private LayerMask movableLayers;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3((float) -5.7, (float) -3.23, 0);
        Collider2D hit = Physics2D.OverlapCircle(pos, 0.2f);
      if (hit && Input.GetMouseButtonUp(0) && int.Parse(hit.name) < 13) {
        int newNum = int.Parse(hit.name) * int.Parse(hit.name);
            DestroyImmediate(hit.gameObject);

          GameObject instance = Instantiate(
                                    cardPrefab, 
                                    Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                                    Quaternion.identity
                                  );

        string[] colors = {"gray", "orange", "white"};
          var randCol = new System.Random();
          int index = randCol.Next(colors.Length);
          string folder = colors[index];
          string folderpath = folder + "/" + newNum.ToString();

          instance.transform.localPosition = new Vector3(instance.transform.position.x, instance.transform.position.y, 0);
              Sprite sprite = Resources.Load<Sprite>(folderpath);
        instance.GetComponent<SpriteRenderer>().sprite = sprite;
        instance.name = newNum.ToString();
        //cardPrefab.GetComponent<SpriteRenderer>().enabled = true;
        instance.GetComponent<SpriteRenderer>().enabled = true;
        score.SendMessage("incrementMerge");

      }
    }
}
