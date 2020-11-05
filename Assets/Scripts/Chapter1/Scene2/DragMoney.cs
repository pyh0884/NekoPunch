using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMoney : Dragable
{
    public DragMoney next;
    public Animator anim;
    public override void Interact()
    {
        if (next)
        {
            GetComponent<Collider2D>().enabled = false;
            next.GetComponent<Collider2D>().enabled = true;
            next.enabled = true;
        }
        else
        {
            FindObjectOfType<StageHelper>().stageIndex += 1;
        }
        anim.SetTrigger("Play");
    }
}
