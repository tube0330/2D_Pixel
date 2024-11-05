using UnityEngine;

public partial class Player : MonoBehaviour
{
    SpriteRenderer sprite;
    Animator ani;
    Rigidbody2D rb;
    Transform tr;

    RaycastHit2D LeftHit;
    RaycastHit2D RightHit;

    const float moveSpeed = 2f;
    const float jumpForce = 6f;
    float leftBoundary = -9f;
    float h = 0f;
    float Left_h = 0f;
    float Right_h = 0f;
    int jumpCnt = 0;
    int maxJumpCnt = 2;

    int hashMove = Animator.StringToHash("isRun");
    int hashJump = Animator.StringToHash("isJump");

    [Header("Ladder")]
    public bool isLadder = false;

    [Header("Tag")]
    const string TileMapTag = "TILEMAP";

    void GetVars()
    {
        tr = transform;

        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        ani.SetBool(hashJump, false);
        ani.SetBool(hashMove, false);
    }

    // 수평 이동
    void HorizontalMove()
    {
        h = Input.GetKey(KeyCode.LeftArrow) ? -1f : Input.GetKey(KeyCode.RightArrow) ? 1f : 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            Left_h = 1f;
        else    // 왼쪽 이동 제한
            Left_h = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
            Right_h = 1f;
        else   // 오른쪽 이동 제한
            Right_h = 0f;

        sprite.flipX = h < 0;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < maxJumpCnt)
        {
            jumpCnt++;
            ani.SetBool("isJump", true);

            // 현재 속도를 초기화하고 점프 힘을 추가
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
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
            rb.gravityScale = 2f;
    }


}
