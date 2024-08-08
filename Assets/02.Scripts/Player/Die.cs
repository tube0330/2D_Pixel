using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Die : MonoBehaviour
{
    Transform tr;

    [Header("Death")]
    public int death = 0;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        if (tr.position.y < -6f)
        {
            //MoveSceneManager.S_instance.LoadStartScene();
            StartCoroutine(ShowDieUI());
        }
    }

    IEnumerator ShowDieUI()
    {
        GameManager.G_instance.BlackImg.color = new Color(0, 0, 0, 255);
        GameManager.G_instance.CharacterImg.enabled = true;
        GameManager.G_instance.Death_txt.enabled = true;
        GameManager.G_instance.Death_txt.text = "X " + ++death;
        tr.position = GameManager.G_instance.startSign.position;
        yield return new WaitForSeconds(2f);
        GameManager.G_instance.BlackImg.color = new Color(0, 0, 0, 0);
        GameManager.G_instance.CharacterImg.enabled = false;
        GameManager.G_instance.Death_txt.enabled = false;
    }
}
