using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem.XR;

public class Player_Controller : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField]
    private float JumpForce = 5f;
    private float Gravity = 0f;
    private Input_Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Input_Controller>();
        controller.Jump += Jump;
        
        direction = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.y += Gravity * Time.deltaTime;
        transform.position +=direction * Time.deltaTime;
    }
    void Jump(object sender,EventArgs e)
    {
        if (FindObjectOfType<GameManager>().Start_Check == false)
        {
            FindObjectOfType<GameManager>().Start_Check = true;
            FindObjectOfType<GameManager>().Press_Start();
            Gravity = -30f;
        }
        direction = Vector3.up * JumpForce;

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lose")
        {
            FindObjectOfType<GameManager>().Lose();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            FindObjectOfType<GameManager>().Increase();
        }
    }
}
