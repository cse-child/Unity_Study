using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 1.0f;

    private float horizontal = 0.0f;
    private float vertical = 0.0f;
    private float mouseX = 0.0f;

    private Vector3 direction;

    private Animator animator;

    // 어지간하면 Awake에서 초기화하고, find같은 함수는 Awake에서 하면안됨
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        
        direction = Vector3.right * horizontal + Vector3.forward * vertical;

        if(direction.sqrMagnitude > 1.0f)
        {
            direction.Normalize();
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotSpeed * mouseX * Time.deltaTime);

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        /*
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos += transform.forward * moveSpeed * Time.deltaTime;
            transform.position = pos;
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime, Space.Self);
        }

        if(Input.GetKey(KeyCode.D))
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot.y += rotSpeed * Time.deltaTime;
            //Quaternion temp = Quaternion.identity;            
            Quaternion temp = new Quaternion();
            temp.eulerAngles = rot;
            transform.rotation = temp;            
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotSpeed * Time.deltaTime);
        }
        */
    }
}
