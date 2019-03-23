using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingFloor : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    void Start()
    {
        Debug.Log("Starting");
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("running");
        if (transform.position.x < -groundHorizontalLength)
        {
            Debug.Log("PLACE BACKGROUND");
            repositionBackground();
        }
    }

    private void repositionBackground()
    {
        Debug.Log("PLACE BACKGROUND2");
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
