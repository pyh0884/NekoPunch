using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutDestroy : MonoBehaviour
{
    public bool isStart;
    public bool notDestroy;
    private SpriteRenderer sr;
    private float alpha = 1;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (isStart)
        {
            alpha -= Time.deltaTime * 1.5f;
            alpha = Mathf.Clamp(alpha, 0, 1);
            sr.color = new Color(1, 1, 1, alpha);
            if (sr.color.a <= 0)
            {
                if (notDestroy)
                {
                    this.enabled = false;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
