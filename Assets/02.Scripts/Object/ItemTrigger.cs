using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    [Header("Tag")]
    string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        {
            GameManager.instance.score++;
            gameObject.SetActive(false);
        }
    }
}
