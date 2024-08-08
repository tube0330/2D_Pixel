using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager G_instance;

    [Header("Canvas")]
    Text score_txt;
    public int score = 0;

    [Header("Die UI")]
    public Transform startSign;
    public Image BlackImg;
    public Image CharacterImg;
    public Text Death_txt;

    void Awake()
    {
        if (G_instance == null)
            G_instance = this;

        else if (G_instance != this)
            Destroy(gameObject);

        score_txt = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();

        startSign = GameObject.Find("StartSign").GetComponent<Transform>();
        BlackImg = GameObject.Find("Canvas").transform.GetChild(1).GetChild(0).GetComponent<Image>();
        CharacterImg = GameObject.Find("Canvas").transform.GetChild(1).GetChild(1).GetComponent<Image>();
        Death_txt = GameObject.Find("Canvas").transform.GetChild(1).GetChild(2).GetComponent<Text>();        

        BlackImg.color = new Color(0, 0, 0, 0);
        CharacterImg.enabled = false;
        Death_txt.enabled = false;
    }

    void Update()
    {
        score_txt.text = $"score {score}";
    }
}