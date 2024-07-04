using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareMachine : MonoBehaviour
{
    public GameObject cardPrefab;
      [SerializeField] private LayerMask movableLayers;
    public GameObject score;
    AudioSource audioSource;
    public AudioClip sparkle;
    public AudioClip bloop;
    private Color color;
    private SpriteRenderer star;
    private GameObject stars;
    public const string ColPass = "colpass";

    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
      stars = GameObject.Find("stars");
      star = stars.GetComponent<SpriteRenderer>();
      color = star.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3((float) -5.7, (float) -3.23, 0);
        Collider2D hit = Physics2D.OverlapCircle(pos, 0.2f);
      if (hit && Input.GetMouseButtonUp(0) && int.Parse(hit.name) < 13) {
        audioSource.pitch = 1.0f;
        audioSource.volume = 0.16f;
        audioSource.PlayOneShot(bloop);

        int newNum = int.Parse(hit.name) * int.Parse(hit.name);

          GameObject instance = Instantiate(
                                    cardPrefab, 
                                    Camera.main.ScreenToWorldPoint(Input.mousePosition), 
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
                folderpath = "white/" + newNum.ToString();
            if (col == 1)
                folderpath = "gray/" + newNum.ToString();
            if (col == 2)
                folderpath = "orange/" + newNum.ToString();
            if (col == 3)
                folderpath = "glass/" + newNum.ToString();

          instance.transform.localPosition = hit.transform.position;
              Sprite sprite = Resources.Load<Sprite>(folderpath);
        instance.GetComponent<SpriteRenderer>().sprite = sprite;
        instance.name = newNum.ToString();
        //cardPrefab.GetComponent<SpriteRenderer>().enabled = true;
        instance.GetComponent<SpriteRenderer>().enabled = true;
        score.SendMessage("incrementMerge");

        stars.SetActive(true);
        Vector3 posi = hit.transform.position;
        stars.transform.position = posi;
        color.a = 1;
        star.color = color;
        //sound
        audioSource.pitch = 1.0f;
        audioSource.volume = 0.4f;
        audioSource.PlayOneShot(sparkle);

        DestroyImmediate(hit.gameObject);
      }
    }
}
