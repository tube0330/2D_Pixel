using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemMove : MonoBehaviour
{
    [Header("Tag")]
    string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        {
            Player playerMove = col.GetComponent<Player>();
            
            if (playerMove != null)
                playerMove.isLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        {
            Player playerMove = col.GetComponent<Player>();

            if (playerMove != null)
                playerMove.isLadder = false;
        }
    }
}
