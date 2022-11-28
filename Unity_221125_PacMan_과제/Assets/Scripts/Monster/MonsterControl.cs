using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    const float FOLLOW_RANGE = 30.0f;
    
    private Transform target;

    private Animator animator;

    private float moveSpeed = 0.7f;

    private Vector3 direction;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if(target != null)
        {
            direction = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction).normalized;
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject.transform;
            print("Player Target Found!");
            animator.SetBool("Run", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        target = null;
        print("Target is Null");
        animator.SetBool("Run", false);
    }
}

