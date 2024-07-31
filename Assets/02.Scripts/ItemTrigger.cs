using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    [Header("Tag")]
    string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(playerTag))
        gameObject.SetActive(false);
    }
}
