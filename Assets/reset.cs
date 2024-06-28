using UnityEngine;
using UnityEngine.UI;

public class Reset : RunGame
{
    void Start()
    {
       
    }
    public void resetLevel()
    {
        GameObject[] cats = GameObject.FindGameObjectsWithTag("number");
            foreach(GameObject cat in cats) {
                if (cat.name != "prefab")
                    Destroy(cat);
            }

            generateNew();
            score.SendMessage("resetForLevel");
        
    }
}