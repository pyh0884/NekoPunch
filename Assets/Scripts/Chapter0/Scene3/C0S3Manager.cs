using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class C0S3Manager : MonoBehaviour
{
    public GameObject[] Items;
    public int stageIndex = 0;
    public float timer;
    public bool finished;
    public int goodCount = 3;
    private float alpha = 0;

    public void NextStage()
    {
        stageIndex += 1;
        timer = 0.0f;
        finished = false;
    }
    void Update()
    {
        if (stageIndex != FindObjectOfType<StageHelper>().stageIndex) NextStage();
        switch (stageIndex)
        {
            case 1://开心1
                if (!finished)
                {
                    Items[2].GetComponent<Animator>().SetTrigger("Change");
                    Items[4].SetActive(true);
                    finished = true;
                }
                break;
            case 2://开心2
                if (!finished)
                {
                    Items[2].GetComponent<Animator>().SetTrigger("Change");
                    Items[5].SetActive(true);
                    finished = true;
                }
                break;
            case 3://开心3
                if (!finished)
                {
                    Items[2].GetComponent<Animator>().SetTrigger("Change");
                    Items[6].SetActive(true);
                    Items[0].GetComponent<Animator>().SetTrigger("Change");
                    Items[1].GetComponent<Animator>().SetTrigger("Change");
                    finished = true;
                }
                break;
            case 4://不爽
                if (!finished)
                {
                    Items[2].GetComponent<Animator>().SetTrigger("Change");
                    Items[7].SetActive(true);
                    Items[0].GetComponent<Animator>().SetTrigger("Change");
                    Items[1].GetComponent<Animator>().SetTrigger("Change");
                    finished = true;
                }
                break;
            case 5://生气
                if (!finished)
                {
                    Items[2].GetComponent<Animator>().SetTrigger("Change");
                    Items[7].SetActive(true);
                    Items[0].GetComponent<Animator>().SetTrigger("Change");
                    Items[1].GetComponent<Animator>().SetTrigger("Change");
                    FindObjectOfType<StageHelper>().stageIndex += 1;
                    finished = true;
                }
                break;
            case 6://播放水幕效果
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer > 1.5f)
                    {
                        Items[8].SetActive(true);
                        finished = true;
                    }
                }
                break;
            case 7://出现标题
                if (!finished)
                {
                    timer += Time.deltaTime;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    alpha += Time.deltaTime * 5 * .3f;
                    Items[9].GetComponent<Image>().color = new Color(1, 0, 0, alpha);
                    if (timer > 1.5f)
                    {
                        SceneManager.LoadScene(4);
                        finished = true;
                    }
                }
                break;
            default: break;
        }
    }
}
