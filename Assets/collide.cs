using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour
{
    private GameObject[] touchingObjects;
    [SerializeField] private LayerMask movableLayers;
    // Start is called before the first frame update
    void Start()
    {
        touchingObjects = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"hi");
        if (Input.GetMouseButtonUp(0)) {
        if (collision.gameObject.layer == movableLayers)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                //spriteRenderer.sprite = Resources.Load<Sprite>(int.Parse(spriteRenderer.sprite.name) * int.Parse(collision.gameObject.name));
                Destroy(collision.gameObject);
            }
        }
    }
}
