using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCon : MonoBehaviour
{

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixdUpdate()
    {
        if (syatihokoCon.win == true)
        {

            animator.SetTrigger("win");

        }
    }
}
