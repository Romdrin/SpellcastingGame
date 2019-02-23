﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private bool CanMove;
    private bool CanAttack;
    public float attackTime = 0.12f;
    //private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        CanMove = true;
        CanAttack = true;
        animator = GetComponent<Animator>();
        //transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        if (CanMove && input != Vector2.zero)
        {
            animator.SetBool("iddle", false);
            animator.SetTrigger("walkAnimation");
            transform.Translate(inputDir * speed * Time.deltaTime, Space.World);
        } else
        {
            animator.SetBool("iddle", true);
        }
        if (CanAttack && Input.GetKey(KeyCode.Mouse0))
        {
            CanMove = false;
            StartCoroutine(magicAttack());
        }
    }

    IEnumerator magicAttack()
    {
        CanMove = false;
        animator.SetBool("attacking", true);
        animator.SetBool("iddle", false);
        CanAttack = false;


        yield return new WaitForSeconds(attackTime);

        animator.SetBool("attacking", false);
        animator.SetBool("iddle", true);
        CanAttack = true;
        CanMove = true;
    }
}
