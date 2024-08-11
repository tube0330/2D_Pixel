using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Die : MonoBehaviour
{
    Transform tr;
    string deadZoneTag = "DEADZONE";
    string startSignTag = "STARTSIGN";

    void Start()
    {
        tr = transform;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(deadZoneTag))
        {
            GameManager.G_instance.isDead = true;
            GameManager.G_instance.death++;
        }

        if(col.gameObject.CompareTag(startSignTag))
            GameManager.G_instance.isDead = false;
    }
}
