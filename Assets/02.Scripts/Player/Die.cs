using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Transform tr;
    string deadZoneTag = "DEADZONE";
    string startSignTag = "STARTSIGN";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(deadZoneTag))
        {
            GameManager.instance.isDead = true;
            GameManager.instance.death++;

        }

        if(col.gameObject.CompareTag(startSignTag))
            GameManager.instance.isDead = false;
    }
}
