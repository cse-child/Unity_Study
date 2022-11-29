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
        // 할당된 Manager를 받아야해서 Awake에서 호출하면 위험할 수 있음
        // GameObject.Find -> 하이어라키 창에서 GameManager인 객체를 다 찾는것
        // Update에서는 사용하면 위험함
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = manager.GetPlayer().transform;

        StartCoroutine(SetState()); // 코루틴 호출
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


    // 코루틴(Coroutine) 코드: 프레임마다 Update를 시키는게 아니라 0.1초정도 마다 실행시켜서 확인하는 것
    // IEnumerator: 시간을 반환? 시간을 딜레이시키는 개념
    // 스레드 개념으로 계속 체크함
    private IEnumerator SetState()
    {
        while(curState != State.DEAD)
        {
            yield return delayTime;

            if (target == null)
                continue;

            float distance = Vector3.Distance(transform.position, target.position);
            
            if (distance < attackRange)
                curState = State.ATTACK;
            else if (distance < traceRange)
                curState = State.TRACE;
            else
                curState = State.IDLE;

            //Physics.CheckSphere(transform.position, traceRange, )
        }
    }

    private void SetAction()
    {
        switch(curState)
        {
            case State.ATTACK:
                Attack();
                break;
            case State.TRACE:
                Trace();
                break;
            case State.IDLE:
                break;
            case State.DEAD:
                break;
        }
    }

    private void Attack()
    {

    }

    private void Trace()
    {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
}