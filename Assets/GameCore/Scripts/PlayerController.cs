using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigid;
    [SerializeField] public float force = 200f;
    [SerializeField] public float speed=3f;
    public bool isDead = false;
    private void Update()
    {
        if (GameStateManager.CurrentState != GameState.Play)
            return;
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }

            Movement();
        }
            
    }

    private void Movement()
    {
        var vel = rigid.velocity;
        vel.x = speed;
        rigid.velocity = vel;
    }

    private void Jump()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up*force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        rigid.velocity = Vector2.zero;
        GameStateManager.CurrentState = GameState.GameOver;
        
    }
    private void Awake()
    {
        GameStateManager.GameStateChanged += GameStateChanged;
    }
    private void GameStateChanged()
    {
        if (GameStateManager.CurrentState == GameState.Idle)
        {
            rigid.velocity = Vector3.zero;
            rigid.isKinematic = true;
            transform.position = Vector3.zero;
        }
        else if (GameStateManager.CurrentState == GameState.Play)
        {
            rigid.isKinematic = false;
            transform.position = Vector2.zero;
            rigid.velocity = Vector2.zero;
            rigid.angularVelocity = 0;
            isDead = false;
        }
    }
}
