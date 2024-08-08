using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffTile : MonoBehaviour
{
    string playerTag = "Player";
    SpriteRenderer spriteRenderer;
    public Sprite offImage;
    Animator ani;
    Rigidbody2D rb;
    BoxCollider2D col;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(playerTag))
            StartCoroutine(Tileoff());
    }

    IEnumerator Tileoff()
    {
        yield return new WaitForSeconds(0.5f);
        ani.enabled = false;
        spriteRenderer.sprite = offImage;
        col.enabled = false;
        rb.isKinematic = false; //-> falling tileA
    }
}
