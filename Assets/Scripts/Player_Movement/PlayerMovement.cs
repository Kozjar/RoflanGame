﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Animator animator;
    private InteractionTrigger trigger;

	void Start () {
        trigger = GetComponent<InteractionTrigger>();
        //animator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        State = CharState.Idle;
        if (Input.GetKey(KeyCode.W))
        {
            trigger.lightAngle = 90;
            //anim.Play("Down_0");
            State = CharState.Up;
            PlayerState.instance.LookAt(PlayerState.look.up);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            trigger.lightAngle = 270;
            State = CharState.Down;
            PlayerState.instance.LookAt(PlayerState.look.down);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            trigger.lightAngle = 0;
            State = CharState.Right;
            PlayerState.instance.LookAt(PlayerState.look.right);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            trigger.lightAngle = 180;
            State = CharState.Left;
            PlayerState.instance.LookAt(PlayerState.look.left);
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + PlayerState.instance.viewDirection, speed * Time.deltaTime);
        }
    }

    public CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }
    public enum CharState
    {
        Idle,
        Left,
        Right,
        Down,
        Up
    }

}
