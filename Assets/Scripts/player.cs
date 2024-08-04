using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Vector3 moveDelta;
    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector3(x, y, 0);

        // swap sprite director
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 0);


        // make this thing move 
        transform.Translate(moveDelta * Time.deltaTime);
    }
}
