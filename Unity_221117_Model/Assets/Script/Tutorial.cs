using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // 접근지정자를 퍼블릭으로 하면 초기값은 스크립트의 영향을 받지 않고
    // 씬에 저장된 데이터의 영향을 받는다.
    //[SerializeField]
    //public int count = 10;

    [HideInInspector]
    public int count = 10;
    

    // 게임 오브젝트가 활성화 될 때 가장 먼저 한번 실행되는 함수
    private void Awake()
    {
        print("Awake");
    }

    // 컴포넌트 또는 게임 오브젝트가 활성화 될 때마다 호출되는 함수
    private void OnEnable()
    {
        print("On Enable");
    }

    // 컴포넌트가 활성화 될 때 한번 호출되는 함수
    // 모든 Awake가 활성화 된 후 Start 활성화
    private void Start()
    {
        print("Start");
    }

    // 프레임마다 호출되는 함수
    private void Update()
    {
       // count++;
        print("count : " + count);
    }

    // 모든 객체들의 Update 함수가 끝나면 호출되는 함수
    private void LateUpdate() // 카메라 구현할 때 많이 사용
    {
        
    }

    // 0.02초마다 호출되는 함수 (Delta Time을 곱한 Update)
    private void FixedUpdate()
    {
        
    }
}
