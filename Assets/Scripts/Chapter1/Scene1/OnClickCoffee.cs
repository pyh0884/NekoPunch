using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCoffee : MonoBehaviour
{
    private MoveCamera moveCam;
    public Animator anim;
    public Vector3 position;
    public GameObject[] others;
    void Start()
    {
        moveCam = FindObjectOfType<MoveCamera>();
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject obj in others)
            {
                obj.SetActive(false);
            }
            moveCam.Move(position);
            anim.SetTrigger("Play");
            Destroy(GetComponent<Collider2D>());
            Destroy(this);
        }
    }
}
