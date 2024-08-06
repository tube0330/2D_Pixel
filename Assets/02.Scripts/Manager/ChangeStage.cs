using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeStage : MonoBehaviour
{
    public static ChangeStage C_instance;

    [Header("Stage OBJ")]
    SpriteRenderer bg;
    [SerializeField] GameObject[] stageObj = new GameObject[3];
    public int boxCnt = 0;

    [Header("random background image")]
    Sprite[] bgSprite;

    void Awake()
    {
        if (C_instance == null)
            C_instance = this;

        else if (C_instance != this)
            Destroy(gameObject);

        bg = GameObject.Find("Background").transform.GetChild(0).GetComponent<SpriteRenderer>(); GetComponent<SpriteRenderer>();

        for (int i = 0; i < stageObj.Length; i++)
            stageObj[i].SetActive(false);

        bgSprite = Resources.LoadAll<Sprite>("BackgroundImg");
    }

    void Start()
    {
        stageObj[0].SetActive(true);
    }

    public void ChangeSetStage()
    {
        switch (boxCnt)
        {
            case 1: //start stage 2
                bg.gameObject.SetActive(false);         //backgound image off
                stageObj[boxCnt - 1].SetActive(false);  //stage_1 off
                RandomBg();                             //Random background image
                bg.gameObject.SetActive(true);          //backgound image on
                stageObj[boxCnt].SetActive(true);       //stage_2 on
                break;

            case 2: //start stage 3
                bg.gameObject.SetActive(false);         //backgound image off
                stageObj[boxCnt - 1].SetActive(false);  //stage_2 off
                RandomBg();                             //Random background image
                bg.gameObject.SetActive(true);          //backgound image on
                stageObj[boxCnt].SetActive(true);       //stage_3 on
                break;

            case 3: //start stage 4
                bg.gameObject.SetActive(false);         //backgound image off
                stageObj[boxCnt - 1].SetActive(false);  //stage_3 off
                RandomBg();                             //Random background image
                bg.gameObject.SetActive(true);          //backgound image on
                stageObj[boxCnt].SetActive(true);       //stage_4 on
                break;
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