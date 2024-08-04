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

    [Header("Stage OBJ")]
    SpriteRenderer bg;
    GameObject obj1, obj2;

    [Header("random background image")]
    Sprite[] bgSprite;

    void Awake()
    {
        if (G_instance == null)
            G_instance = this;

        else if (G_instance != this)
            Destroy(gameObject);

        score_txt = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();

        bg = GameObject.Find("Background").transform.GetChild(0).GetComponent<SpriteRenderer>(); GetComponent<SpriteRenderer>();

        obj1 = GameObject.Find("_OBJECT_1");
        obj2 = GameObject.Find("_OBJECT_2");
        obj1.SetActive(true);
        obj2.SetActive(false);

        bgSprite = Resources.LoadAll<Sprite>("BackgroundImg");
    }

    void Update()
    {
        score_txt.text = $"score: {score}";
    }

    //첫번째 obj 끄기
    public void OffObject(bool isoff)
    {
        if (isoff)
        {
            bg.gameObject.SetActive(false); //배경 이미지 off
            obj1.SetActive(false);          //첫번째 스테이지 off

            RandomBg();                     //배경 이미지 랜덤하게 변경
            bg.gameObject.SetActive(true);  //배경이미지 on
            obj2.SetActive(true);           //두번째 스테이지 시작

            RandomBg();                     //배경 이미지 랜덤하게 변경
            bg.gameObject.SetActive(true);  //배경이미지 on
            obj2.SetActive(false);           //두번째 스테이지 시작
        }
    }

    //랜덤 배경이미지로 번경
    void RandomBg()
    {
        int idx = Random.Range(0, bgSprite.Length);
        bg.sprite = bgSprite[idx];

        bg.gameObject.SetActive(true);
    }
}
