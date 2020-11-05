using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeButton : MonoBehaviour
{
    private Animator anim;
    public SpriteRenderer[] sprites;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Play");
            StartCoroutine(destroyAfterAnim());
        }
    }
    IEnumerator destroyAfterAnim() 
    {
        yield return new WaitForSeconds(2.0f);
        foreach (SpriteRenderer sr in sprites)
        {
            sr.enabled = false;
        }
        FindObjectOfType<MoveCamera>().Move(new Vector3(0, 5, -10));
        Destroy(gameObject);
    }
}
