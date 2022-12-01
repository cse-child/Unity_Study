using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    private readonly int hashAttack = Animator.StringToHash("Attack");
    private readonly int hashJump = Animator.StringToHash("Jump");

    private bool isAttack = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!isAttack && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(hashAttack);
            isAttack = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(hashJump);            
        }
    }

    private void EndAttack()
    {
        isAttack = false;
    }
}
