using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // ���������ڸ� �ۺ����� �ϸ� �ʱⰪ�� ��ũ��Ʈ�� ������ ���� �ʰ�
    // ���� ����� �������� ������ �޴´�.
    //[SerializeField]
    //public int count = 10;

    [HideInInspector]
    public int count = 10;
    

    // ���� ������Ʈ�� Ȱ��ȭ �� �� ���� ���� �ѹ� ����Ǵ� �Լ�
    private void Awake()
    {
        print("Awake");
    }

    // ������Ʈ �Ǵ� ���� ������Ʈ�� Ȱ��ȭ �� ������ ȣ��Ǵ� �Լ�
    private void OnEnable()
    {
        print("On Enable");
    }

    // ������Ʈ�� Ȱ��ȭ �� �� �ѹ� ȣ��Ǵ� �Լ�
    // ��� Awake�� Ȱ��ȭ �� �� Start Ȱ��ȭ
    private void Start()
    {
        print("Start");
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    private void Update()
    {
       // count++;
        print("count : " + count);
    }

    // ��� ��ü���� Update �Լ��� ������ ȣ��Ǵ� �Լ�
    private void LateUpdate() // ī�޶� ������ �� ���� ���
    {
        
    }

    // 0.02�ʸ��� ȣ��Ǵ� �Լ� (Delta Time�� ���� Update)
    private void FixedUpdate()
    {
        
    }
}
