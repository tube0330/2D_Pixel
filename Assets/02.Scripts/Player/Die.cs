using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    string deadZoneTag = "DEADZONE";
    string startSignTag = "STARTSIGN";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(deadZoneTag))
        {
            GameManager.G_instance.isDead = true;
            GameManager.G_instance.death++;
            OnOffTile.T_Instance.Tileon();
        }

        if(col.gameObject.CompareTag(startSignTag))
            GameManager.G_instance.isDead = false;
    }
}
