using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Transform tr;
    [SerializeField] Animator ani;
    [SerializeField] Rigidbody2D rb;
    float speed = 3f;
    float jumpForce = 3f;
    [SerializeField] float h;
    [SerializeField] bool isJump = false;

    void Start()
    {
        tr = transform;
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        h = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            h = -1f;
            sprite.flipX = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            h = 1f;
            sprite.flipX = false;
        }

        // 속도 적용
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        // 애니메이션 설정
        if (Mathf.Abs(h) > 0)
            ani.SetBool("isRun", true);

        else
            ani.SetBool("isRun", false);

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            ani.SetBool("isJump", isJump);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("TILEMAP"))
        {
            isJump = false;
            ani.SetBool("isJump", isJump);
        }
    }
}
