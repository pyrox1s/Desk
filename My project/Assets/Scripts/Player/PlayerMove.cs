using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float jumpForce = 5f; // Сила прыжка
    public float fallAcceleration = 9.8f; // Ускорение падения

    private Rigidbody rb;
    private bool isJumping = false;

    //переменные для передвижения
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
        //Вызов Ходьбы
        Walk();

        //вызов поворота игрока
        ReflectLeft();
        ReflectRight();

        //Вызов Прыжка
        IsJumping();
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(Vector3.down * fallAcceleration, ForceMode.Acceleration);
        }
    }

    //Реализация Прыжка
    private void Jump()
    {
        isJumping = true;
        rb.velocity = Vector3.up * jumpForce;
    }
    private void IsJumping() // проверка прыжка
    {
        //Вызов Прыжка
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
    }

    //Передвижение Игрока
    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * _speedInRealTime, rb.velocity.y);
    }



    //Проверка столкновения с коллайерами
    private void OnCollisionStay(Collision coll)
    {
        //Проверка Земли(устарело)
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



    // поворот персонажа в лево со scale -1
    public bool faceRight = true;
    void ReflectLeft()
    {
        if (moveVector.x < 0 )
        {
            transform.localScale = new Vector3(-1, 1, 1);
   
        }
    }
    // поворот персонажа обратно в право со scale 1

    void ReflectRight()
    {
        if (moveVector.x > 0 )
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceRight = !faceRight;
        }
    }

    public void SlowSlip() //замедление передвижения если игрок стоит на конвеере
    {
        _speedInRealTime = _slowSpeed;
    }

    public void NormalWalk() //возвращаем нормальную скорость если игрок НЕ стоит на ковеере 
    {
        _speedInRealTime = _normalSpeed;
    }
}