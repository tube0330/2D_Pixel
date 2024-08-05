using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager sG_instance;

    [Header("Canvas")]
    private Text score_txt;
    public int score = 0;

     void Awake()
    {
        if (sG_instance == null)
            sG_instance = this;

        else if (sG_instance != this)
            Destroy(gameObject);

        score_txt = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        score_txt.text = $"score: {score}";
    }
}
