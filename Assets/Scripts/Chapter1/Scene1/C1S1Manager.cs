using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C1S1Manager : MonoBehaviour
{
    public GameObject[] Items;
    public SpriteRenderer[] bubbles;
    public int stageIndex = 1;
    public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public int ActionsCount = 3;
    public float alpha = 0;
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
        Items[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Items[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Items[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Items[4].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Items[5].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Items[6].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        foreach (SpriteRenderer sr in bubbles)
        {
            sr.color = new Color(1, 1, 1, 0);
        }
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
            //标题
            case 0:
                if (!finished)
                {
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    Items[0].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - alpha);
                    if (alpha == 1)
                    {
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        finished = true;
                    }
                }
                break;
            //显示兔兔跟猫猫
            case 1:
                if (!finished)
                {
                    alpha += Time.deltaTime * 5 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    Items[1].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    timer += Time.deltaTime;
                    if (timer > 1.2f && alpha == 1) 
                    {
                        moveCam.Move(new Vector3(0, 5, -10));
                        finished = true;
                    }
                }
                break;
            //显示气泡
            case 2:
                if (!finished)
                {
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    Items[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    Items[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    Items[4].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    Items[5].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    Items[6].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    foreach (SpriteRenderer sr in bubbles)
                    {
                        sr.color = new Color(1, 1, 1, alpha);
                    }
                    if (alpha == 1)
                    {
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        finished = true;
                    }
                }
                break;
            //打开碰撞体
            case 3:
                if (!finished)
                {
                    Items[2].GetComponent<Collider2D>().enabled = true;
                    Items[3].GetComponent<Collider2D>().enabled = true;
                    Items[4].GetComponent<Collider2D>().enabled = true;
                    FindObjectOfType<StageHelper>().stageIndex += 1;
                    finished = true;
                }
                break;
            //三个场景结束
            case 13:
                if (!finished)
                {
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    foreach (SpriteRenderer sr in bubbles)
                    {
                        sr.color = new Color(1, 1, 1, 1 - alpha);
                    }
                    if (alpha == 1)
                    {
                        moveCam.Move(new Vector3(0, 0, -10));
                        finished = true;
                    }
                }
                break;
            case 14:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer >= 2.0f)
                    {
                        SceneManager.LoadScene(6);
                        finished = true;
                    }
                }
                break;
        }
    }
}