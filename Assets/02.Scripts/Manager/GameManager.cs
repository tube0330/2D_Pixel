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

    [Header("Die")]
    Transform playerTr;
    public Transform startSign;
    public Image BlackImg;
    public Image CharacterImg;
    public Text Death_txt;
    public int death = 0;
    public bool isDead = false;

    [Header("ItemOnOff")]
    public List<GameObject> item1 = new List<GameObject>();


    void Awake()
    {
        if (G_instance == null)
            G_instance = this;

        else if (G_instance != this)
            Destroy(gameObject);

        score_txt = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();

        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        startSign = GameObject.Find("StartSign").GetComponent<Transform>();
        BlackImg = GameObject.Find("Canvas").transform.GetChild(1).GetChild(0).GetComponent<Image>();
        CharacterImg = GameObject.Find("Canvas").transform.GetChild(1).GetChild(1).GetComponent<Image>();
        Death_txt = GameObject.Find("Canvas").transform.GetChild(1).GetChild(2).GetComponent<Text>();

        BlackImg.color = new Color(0, 0, 0, 0); //black Image off
        CharacterImg.enabled = false;           //character Image off
        Death_txt.enabled = false;              //death text off

        GameObject[] obj1_item = GetComponentsInChildren<GameObject>();
        foreach (GameObject item in obj1_item)
            items.Add(item);
    }

    void Start()
    {
        
    }

    void Update()
    {
        score_txt.text = $"score {score}";

        if (isDead)
            StartCoroutine(ShowDieUI());
    }

    IEnumerator ShowDieUI()
    {
        BlackImg.color = new Color(0, 0, 0, 255);   //black Image on
        CharacterImg.enabled = true;                //character Image on
        Death_txt.enabled = true;                   //death text on
        Death_txt.text = "X " + death;              //show death count
        playerTr.position = startSign.position;     //player position reset

        yield return new WaitForSeconds(2f);
        BlackImg.color = new Color(0, 0, 0, 0);     //black Image off
        CharacterImg.enabled = false;               //character Image off
        Death_txt.enabled = false;                  //death text off

        /* foreach (GameObject item in items)
            item.SetActive(true); */
    }
}