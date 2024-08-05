using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    [Header ("Move background")]
    private Transform tr;
    private BoxCollider2D boxcol;
    private float speed = 1f;
    private float width;

    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
        tr = GetComponent<Transform>();
        width = boxcol.size.x;
    }

    void Update()
    {
        tr.Translate(Vector2.left * speed * Time.deltaTime);

        if (tr.position.x <= -width/2)
        {
            RePosition();
        }
    }

    void RePosition()
    {
        Vector2 pos = new Vector3(width, 0f, tr.position.z);
        tr.position = pos + (Vector2)tr.position;
    }
}