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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        {
            playerTr.position = new Vector3(40f, playerTr.position.y, playerTr.position.z);
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            playerTr.position = new Vector3(20f, playerTr.position.y, playerTr.position.z);
            gameObject.SetActive(false);

            GameManager.G_instance.OffBackground(true); // all off first obj
        }
    }
}
