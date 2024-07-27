using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform tr;
    [SerializeField] Animator ani;
    float jump_h = 1f;
    bool isJump = false;

    void Start()
    {
        tr = transform;
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            ani.SetTrigger("Jump");
            tr.Translate(Vector2.up * jump_h);
        }
    }
}
