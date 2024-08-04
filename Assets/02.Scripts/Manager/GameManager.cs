using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager G_instance;

    [Header("Canvas")]
    private Text score_txt;
    public int score = 0;

    [Header("off all objects for the next stage")]
    SpriteRenderer bg;
    GameObject obj_1;

    void Awake()
    {
        if (G_instance == null)
            G_instance = this;

        else if (G_instance != this)
            Destroy(gameObject);

        score_txt = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();

        bg = GameObject.Find("Background").transform.GetChild(0).GetComponent<SpriteRenderer>();GetComponent<SpriteRenderer>();
        obj_1 = GameObject.Find("_OBJECT_1");
    }

    void Update()
    {
        score_txt.text = $"score: {score}";
    }

    //첫번째 bg 끄기
    public void OffBackground(bool isoff)
    {
        if (isoff)
        {
            bg.gameObject.SetActive(false);
            obj_1.gameObject.SetActive(false);
        }
    }
}
