using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageBox : MonoBehaviour
{
    [Header("Tag")]
    string playerTag = "Player";

    [Header("Move to next stage")]
    Transform playerTr;

    void Start()
    {
        playerTr = GameObject.FindWithTag(playerTag).GetComponent<Transform>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            playerTr.position = new Vector3(-6.7f, 0.3f, playerTr.position.z);
            gameObject.SetActive(false);    //박스 끄기

            GameManager.G_instance.OffObject(true); // all off first obj
        }
    }
}
