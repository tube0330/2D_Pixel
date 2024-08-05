using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator ani;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform tr;
    float moveSpeed = 2f;
    float jumpForce = 3.5f;
    float h = 0f;
    int jumpCnt = 0;
    int maxJumpCnt = 2;

    [Header("Ladder")]
    public bool isLadder = false;

    [Header("Tag")]
    string TileMapTag = "TILEMAP";

    void Start()
    {
        tr = transform;
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalMove();
        Jump();

        //왼쪽 이동 제한 
        if (tr.position.x < -9f)
        {
            tr.position = new Vector3(-9f, tr.position.y, tr.position.z);
        }
    }

    //수평이동
    void HorizontalMove()
    {
        h = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            h = -1f;
            sprite.flipX = true;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            h = 1f;
            sprite.flipX = false;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < maxJumpCnt)
        {
            jumpCnt++;
            ani.SetBool("isJump", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //이동
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        // 애니메이션 설정
        if (Mathf.Abs(h) > 0)
            ani.SetBool("isRun", true);

        else
            ani.SetBool("isRun", false);

        //사다리 이동
        LadderMove();
    }

    void LadderMove()
    {
        if (isLadder)
        {
            float v = Input.GetAxis("Vertical");
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, v * moveSpeed);
        }

        else
            rb.gravityScale = 1f;
    }

    //JumpCnt 초기화로 무한 점프 막기
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TileMapTag))
        {
            jumpCnt = 0;
            ani.SetBool("isJump", false);
        }
    }
}
