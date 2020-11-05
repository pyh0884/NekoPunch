using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerChange : MonoBehaviour
{
    private Animator anim;
    public GameObject[] stages;
    private int count = 0;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            switch (count)
            {
                case 1:
                    stages[0].GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 2:
                    stages[0].GetComponent<SpriteRenderer>().enabled = false;
                    stages[1].GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 3:
                    stages[1].GetComponent<SpriteRenderer>().enabled = false;
                    stages[2].GetComponent<SpriteRenderer>().enabled = true;
                    break;
            }
            if (count == 3) 
            {
                anim.SetTrigger("Play");
                FindObjectOfType<MoveCamera>().Move(new Vector3(0, 5, -10));
                Destroy(GetComponent<Collider2D>());
                Destroy(this);
            }
        }
    }
}
