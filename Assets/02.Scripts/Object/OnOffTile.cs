using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffTile : MonoBehaviour
{
    public static OnOffTile T_Instance;

    string playerTag = "Player";
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite offImage;
    [SerializeField] Sprite onImage;
    Animator ani;
    Rigidbody2D rb;
    BoxCollider2D col;
    
    Transform tr;
    Transform tileTr;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        tr = transform;
        tileTr = transform.GetChild(0).GetComponent<Transform>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(playerTag))
            StartCoroutine(Tileoff());
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

    public IEnumerator Tileon()
    {
        tr = tileTr;
        ani.enabled = true;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = onImage;
        col.enabled = true;
        rb.isKinematic = true;

        yield return new WaitForSeconds(3f);
        gameObject.SetActive(true);
    }
}
