using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 1.0f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.z += moveSpeed * Time.deltaTime;
            transform.position = pos;
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime);
        }
        
        //Quaternion;
        // 복소수로 이루어짐 (라디안 값X), atan/cos같은건 무조건 라디안 값으로
        if(Input.GetKey(KeyCode.D))
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot.y += rotSpeed * Time.deltaTime;
            //Quaternion temp = Quaternion.identity; // Rotation 0,0,0 넣는거
            Quaternion temp = new Quaternion();
            temp.eulerAngles = rot;
            transform.rotation = temp;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotSpeed * Time.deltaTime);
        }
    }
}
