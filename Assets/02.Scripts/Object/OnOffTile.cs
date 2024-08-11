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
    BoxCollider2D col;

    public Transform tileTr;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        tileTr = transform.GetChild(0).GetComponent<Transform>();
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
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    IEnumerator Tileon()
    {
        gameObject.SetActive(true);
        rb.isKinematic = true;
        spriteRenderer.sprite = onImage;
        col.enabled = true;
        ani.enabled = true;

        yield return new WaitForSeconds(1f);
        transform.position = tileTr.position;
    }
}
