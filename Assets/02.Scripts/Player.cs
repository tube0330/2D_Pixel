using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator ani;
    [SerializeField] Rigidbody2D rb;
    float speed = 3f;
    float jumpForce = 3f;
    float h = 0f;
    int jumpCnt = 0;
    int maxJumpCnt = 1;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalMove();

        Jump();
    }

    private void HorizontalMove()
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
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < maxJumpCnt)
        {
            jumpCnt++;
            ani.SetBool("isJump", true);
            //rb.velocity = new Vector2(rb.velocity.x, 0); // 수직 속도 초기화
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //이동
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        // 애니메이션 설정
        if (Mathf.Abs(h) > 0)
            ani.SetBool("isRun", true);

        else
            ani.SetBool("isRun", false);
    }

    //JumpCnt 초기화로 무한 점프 막기
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("TILEMAP"))
        {
            jumpCnt = 0;
            ani.SetBool("isJump", false);
        }
    }
}
