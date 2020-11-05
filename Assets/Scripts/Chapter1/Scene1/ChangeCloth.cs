using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCloth : Dragable
{
    public Vector3 originalPosition;
    public GameObject targetCloth;
    public GameObject other;
    public override void Interact()
    {
        targetCloth.transform.position = originalPosition;
        FindObjectOfType<MoveCamera>().Move(new Vector3(0, 5, -10));
        GetComponentInParent<Animator>().SetTrigger("Play");
        Destroy(other.GetComponent<ChangeCloth>());
        Destroy(other.GetComponent<Collider2D>());
        Destroy(this);
        Destroy(GetComponent<Collider2D>());
    }
}
