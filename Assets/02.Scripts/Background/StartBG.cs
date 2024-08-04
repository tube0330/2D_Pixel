using UnityEngine;

public class StartBG : MonoBehaviour
{
    Transform tr;
    float speed = 1f; // 이동 속도
    float startPosX;
    float w;
    bool moveLeft = true;

    void Start()
    {
        tr = GetComponent<Transform>();
        startPosX = tr.position.x;  // 시작 위치 저장 및 배경 이미지 가로 길이 계산
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        w = sprite.size.x;
    }

    void Update()
    {
        if (moveLeft)
        {
            tr.Translate(Vector3.left * speed * Time.deltaTime);

            if (tr.position.x <= startPosX - w)
                moveLeft = false;
        }

        else
        {
            tr.Translate(Vector3.right * speed * Time.deltaTime);

            if (tr.position.x >= startPosX)
                moveLeft = true;
        }
    }
}
