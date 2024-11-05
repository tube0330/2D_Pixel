using UnityEngine;

public partial class Player : MonoBehaviour
{
    void Start()
    {
        GetVars();
    }

    void Update()
    {
        LeftHit = GetRaycast(tr.position, Vector2.left, Left_h, 1 << 7);
        if (LeftHit.collider != null)
            Debug.Log(LeftHit.collider.name);

        RightHit = GetRaycast(tr.position, Vector2.right, Right_h, 1 << 7);
        if (RightHit.collider != null)
            Debug.Log(RightHit.collider.name);
        HorizontalMove();
        Jump();

        // 왼쪽 이동 제한
        if (tr.position.x < leftBoundary)
            tr.position = new Vector3(leftBoundary, tr.position.y, tr.position.z);
    }

    void FixedUpdate()
    {
        // 이동
        bool canMove = true;
        if (LeftHit.collider != null && LeftHit.distance < 0.6f && h == -1)
            canMove = false;
        else if (RightHit.collider != null && RightHit.distance < 0.6f && h == 1)
            canMove = false;
        else canMove = true;
        
        if (canMove)
            rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        // 애니메이션 설정
        ani.SetBool(hashMove, Mathf.Abs(h) > 0);

        // 사다리 이동
        LadderMove();
    }

    // JumpCnt 초기화로 무한 점프 막기
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TileMapTag))
        {
            jumpCnt = 0;
            ani.SetBool("isJump", false);
        }
    }
}