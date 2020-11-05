using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C1S2Manager : MonoBehaviour
{
    public GameObject[] Items;
    public int stageIndex = 1;
    public float timer;
    private MoveCamera moveCam;
    public bool finished;
    public float alpha = 0;
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
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
            //播放日历动画
            case 1:
                if (!finished)
                {
                    Items[0].GetComponent<Animator>().SetTrigger("Play");
                    finished = true;
                }
                break;
            //移动镜头到第二分镜
            case 2:
                if (!finished)
                {
                    moveCam.Move(new Vector3(0, -10.8f, 0));
                    finished = true;
                }
                break;
            //允许摄像机滚动
            case 3:
                if (!finished)
                {
                    moveCam.GetComponent<DragCamera>().enabled = true;
                    finished = true;
                }
                break;
            //关闭摄像机滚动
            case 4:
                if (!finished)
                {
                    moveCam.GetComponent<DragCamera>().enabled = false;
                    Items[1].GetComponent<Collider2D>().enabled = true;
                    finished = true;
                }
                break;
            //点击事件1
            case 5:
                if (!finished)
                {
                    Items[1].GetComponent<Collider2D>().enabled = false;
                    Items[2].SetActive(true);
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    Items[2].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    if (alpha == 1)
                    {
                        Items[4].GetComponent<Collider2D>().enabled = true;
                        FindObjectOfType<StageHelper>().stageIndex += 1;
                        finished = true;
                    }
                }
                break;
            //点击事件2
            case 7:
                if (!finished)
                {
                    Items[3].SetActive(true);
                    alpha += Time.deltaTime * 3 * .3f;
                    alpha = Mathf.Clamp(alpha, 0, 1);
                    Items[3].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                    if (alpha == 1)
                    {
                        moveCam.Move(new Vector3(0, -75.6f, -10));
                        finished = true;
                    }
                }
                break;
            case 9:
                if (!finished)
                {
                    moveCam.Move(new Vector3(0, -88, 0));
                    finished = true;
                }
                break;
            case 10:
                if (!finished)
                {
                    timer += Time.deltaTime;
                    if (timer >= 2.0f)
                    {
                        SceneManager.LoadScene(7);
                        finished = true;
                    }
                }
                break;
        }
    }
}
