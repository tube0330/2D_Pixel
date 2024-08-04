using UnityEngine;

public class LRMove : MonoBehaviour
{
    Transform tr;
    float speed = 1f; // 이동 속도
    float startPosX;
    float w;
    bool moveLeft = true;

    void Start()
    {
        tr = GetComponent<Transform>();
        startPosX = tr.position.x;
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
