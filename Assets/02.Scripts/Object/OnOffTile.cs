using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffTile : MonoBehaviour
{
    string playerTag = "Player";
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite offImage;
    [SerializeField] Sprite onImage;
    Animator ani;
    Rigidbody2D rb;
    Collider2D col;

    public Transform tileTr;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(playerTag))
            StartCoroutine(Tileoff());
    }

    void Update()
    {
        if (GameManager.G_instance.isDead)
            StartCoroutine(Tileon());
    }

    IEnumerator Tileoff()
    {
        ani.enabled = false;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = offImage;
        col.enabled = false;
        rb.isKinematic = false; //-> falling tile
        yield return new WaitForSeconds(2f);
        rb.gravityScale = 0f;
        spriteRenderer.enabled = false;
    }

    IEnumerator Tileon()
    {
        col.enabled = true;
        rb.isKinematic = true;
        spriteRenderer.sprite = onImage;
        ani.enabled = true;

        yield return new WaitForSeconds(1f);
        
        Debug.Log(tileTr.transform.position);
        transform.position = tileTr.position;
    }
}
