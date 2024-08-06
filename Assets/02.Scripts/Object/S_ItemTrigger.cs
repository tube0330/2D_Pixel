using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemTrigger : MonoBehaviour
{
    [Header("Tag")]
    string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        {
            S_GameManager.sG_instance.score++;
            gameObject.SetActive(false);
        }
    }
}
