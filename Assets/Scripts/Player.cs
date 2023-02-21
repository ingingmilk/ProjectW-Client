using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;    
    public float speed;
    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer[] spriters;
    Animator anim;
   
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriters = GetComponentsInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }
   
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(inputVec.x, inputVec.y);
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriters[0].flipX = inputVec.x < 0;
            spriters[1].flipX = inputVec.x < 0;
        }
    }
}
