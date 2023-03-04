using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 20;
    public int itemCount;
    int isJump;
    public float Speed = 10.0f;
    float h, v;
    Rigidbody rigid;

    void Awake()
    {
        isJump = 0;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isJump<=1)
        {
            isJump=isJump+1;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
            isJump = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Item_Cube")
        {
            itemCount++;
            other.gameObject.SetActive(false);
        }
    }
}
