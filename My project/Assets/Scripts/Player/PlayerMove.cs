using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float jumpForce = 5f; // ���� ������
    public float fallAcceleration = 9.8f; // ��������� �������

    private Rigidbody rb;
    private bool isJumping = false;

    //���������� ��� ������������
    public float _speedInRealTime = 2f;
    public float _normalSpeed;
    public float _slowSpeed;
    public Vector3 moveVector;


    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _speedInRealTime = _normalSpeed;
    }

    private void Update()
    {
        //����� ������
        Walk();

        //����� �������� ������
        ReflectLeft();
        ReflectRight();

        //����� ������
        IsJumping();
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(Vector3.down * fallAcceleration, ForceMode.Acceleration);
        }
    }

    //���������� ������
    private void Jump()
    {
        isJumping = true;
        rb.velocity = Vector3.up * jumpForce;
    }
    private void IsJumping() // �������� ������
    {
        //����� ������
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }

    //������������ ������
    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * _speedInRealTime, rb.velocity.y);
    }



    //�������� ������������ � �����������
    private void OnCollisionStay(Collision coll)
    {
        //�������� �����(��������)
        if (coll.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (coll.gameObject.CompareTag("Conveyor"))
        {
            SlowSlip();

        }
        
    }
    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("Conveyor"))
        {
            NormalWalk();
        }
    }



    // ������� ��������� � ���� �� scale -1
    public bool faceRight = true;
    void ReflectLeft()
    {
        if (moveVector.x < 0 )
        {
            transform.localScale = new Vector3(-1, 1, 1);
   
        }
    }
    // ������� ��������� ������� � ����� �� scale 1

    void ReflectRight()
    {
        if (moveVector.x > 0 )
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceRight = !faceRight;
        }
    }

    public void SlowSlip() //���������� ������������ ���� ����� ����� �� ��������
    {
        _speedInRealTime = _slowSpeed;
    }

    public void NormalWalk() //���������� ���������� �������� ���� ����� �� ����� �� ������� 
    {
        _speedInRealTime = _normalSpeed;
    }
}