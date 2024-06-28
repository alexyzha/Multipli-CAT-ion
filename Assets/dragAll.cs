using UnityEngine;

public class dragAll : MonoBehaviour {
  [SerializeField] private LayerMask movableLayers;
  [SerializeField] private bool isMoveRestrictedToScreen = true;

  public GameObject cardPrefab;
  public GameObject score;

  private Transform dragging = null;
  private Vector3 offset;
  private Vector3 extents;

  // Update is called once per frame
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      // Cast our own ray.
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
                                           Vector2.zero, float.PositiveInfinity, movableLayers);
      if (hit) {
        // If we hit, record the transform of the object we hit.
        dragging = hit.transform;
        // And record the offset.
        offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("ahead");
        // Record the size of the sprite so we can limit it to the screen if necessary.
        extents = dragging.GetComponent<SpriteRenderer>().sprite.bounds.extents;
      }
    } else if (Input.GetMouseButtonUp(0)) {
      // Stop dragging.
        if (dragging != null)
          dragging.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Default");
        dragging = null;
        Collider2D[] collider2Ds;

        collider2Ds = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.2f);
        

        //for NEWNUM random folder
        int newNum = 1;
        if (collider2Ds.Length == 2 && int.Parse(collider2Ds[0].name) * int.Parse(collider2Ds[1].name) < 145) {
          foreach (var collider in collider2Ds)
          {
            newNum *= int.Parse(collider.name);
              DestroyImmediate(collider.gameObject);
          }

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
        
        //end newnum

    }

    if (dragging != null) {
      Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
      if (isMoveRestrictedToScreen) {
        // Find the screen bounds in world coordinates.
        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        // Limit to the screen
        pos.x = Mathf.Clamp(pos.x, bottomLeft.x + extents.x, topRight.x - extents.x);
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y + extents.y, topRight.y - extents.y);
      }
      // Set the target objects position.
      dragging.position = pos;
    }
  }
}