using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutDestroy : MonoBehaviour
{
    public bool isStart;
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
                Destroy(gameObject);
            }
        }
    }
}
