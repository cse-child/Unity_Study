using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    enum State
    {
        IDLE, TRACE, ATTACK, DEAD
    }

    public float traceRange = 5.0f;
    public float attackRange = 1.0f;

    public float moveSpeed = 0.5f;

    private Animator animator;

    private State curState;

    private GameManager manager;
    private Transform target;

    private readonly WaitForSeconds delayTime = new WaitForSeconds(0.1f);

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = manager.GetPlayer().transform;

        StartCoroutine(SetState());
    }

    private void Update()
    {
        SetAction();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, traceRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);        
    }

    private IEnumerator SetState()
    {
        while(curState != State.DEAD)
        {
            yield return delayTime;

            if (target == null)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            
            if (distance < attackRange)
                curState = State.ATTACK;
            else if (distance < traceRange)
                curState = State.TRACE;
            else
                curState = State.IDLE;

            //Physics.CheckSphere(transform.position, traceRange);
        }        
    }

    private void SetAction()
    {
        switch(curState)
        {
            case State.TRACE:
                Trace();
                break;
        }
    }

    private void Trace()
    {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
}
