using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C1S3Manager : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject[] bubbles;
    public int stageIndex = 0;
    public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public float alpha = 0;
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
        bubbles[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        bubbles[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        bubbles[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        bubbles[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        bubbles[4].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        bubbles[5].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    public void NextStage()
    {
        stageIndex += 1;
        timer = 0.0f;
        alpha = 0;
        finished = false;
    }
    void Update()
    {
        if (stageIndex != FindObjectOfType<StageHelper>().stageIndex) NextStage();
        switch (stageIndex)
        {
            //猫猫兔兔上车
            case 1:
                if (!finished)
                {
                    moveCam.Move(new Vector3(0, -10.8f, -10));
                    finished = true;
                }
                break;
            //上车后
            case 2:
                if (!finished)
                {
                    Items[0].GetComponent<Collider2D>().enabled = true;
                    finished = true;
                }
                break;
            //白天对话
            case 3:
                if (!finished)
                {
                    Items[0].GetComponent<Collider2D>().enabled = false;
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    bubbles[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    bubbles[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    if (alpha == 1)
                    {
                        Items[0].GetComponent<Collider2D>().enabled = true;
                        finished = true;
                    }
                }
                break;
            //黄昏
            case 4:
                if (!finished)
                {
                    Destroy(Items[1]);
                    Items[2].SetActive(true);
                    finished = true;
                }
                break;
            //黄昏对话
            case 5:
                if (!finished)
                {
                    Items[0].GetComponent<Collider2D>().enabled = false;
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    bubbles[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    bubbles[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    if (alpha == 1)
                    {
                        Items[0].GetComponent<Collider2D>().enabled = true;
                        finished = true;
                    }
                }
                break;
            //夜晚
            case 6:
                if (!finished)
                {
                    Destroy(Items[2]);
                    Items[3].SetActive(true);
                    finished = true;
                }
                break;
            //夜晚对话
            case 7:
                if (!finished)
                {
                    Items[0].GetComponent<Collider2D>().enabled = false;
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    bubbles[4].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    bubbles[5].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    if (alpha == 1)
                    {
                        Items[0].GetComponent<Collider2D>().enabled = true;
                        finished = true;
                    }
                }
                break;
            //公车开过
            case 8:
                if (!finished)
                {
                    Items[0].GetComponent<Collider2D>().enabled = false;
                    Items[4].transform.position += new Vector3(Time.deltaTime * 15, 0, 0);
                    if (Items[4].transform.position.x > 0.45f)
                    {
                        Destroy(Items[5]);
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        finished = true;                        
                    }
                }
                break;
            //公车离开屏幕
            case 9:
                if (!finished)
                {
                    Items[4].transform.position += new Vector3(Time.deltaTime * 15, 0, 0);
                    if (Items[4].transform.position.x > 30)
                    {
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        finished = true;
                    }
                }
                break;
            //站牌
            case 10:
                if (!finished)
                {
                    Items[6].GetComponent<Animator>().SetTrigger("Play");
                    finished = true;
                }
                break;
            //移动镜头到2-3-3
            case 11:
                if (!finished)
                {
                    moveCam.Move(new Vector3(0, -21.6f, 0));
                    finished = true;
                }
                break;
            //移动镜头到2-3-3
            case 12:
                if (!finished)
                {
                    Items[10].GetComponent<Collider2D>().enabled = true;
                    finished = true;
                }
                break;
            //递锤子
            case 13:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > 1)
                    {
                        alpha += Time.deltaTime * 3 * .3f;
                        alpha = Mathf.Clamp(alpha, 0, 1);
                        Items[7].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - alpha);
                        Items[9].GetComponent<Image>().color = new Color(1, 1, 1, alpha);
                        if (alpha == 1)
                        {
                            Items[8].SetActive(true);
                            finished = true;
                        }
                    }
                }
                break;
        }
    }

}
