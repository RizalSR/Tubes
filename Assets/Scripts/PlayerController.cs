﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isJump = true;
    bool isDead = false;
    int idMove = 0;
    Animator anim;
    private AudioSource audio1;
	public AudioClip audioclip1;
    
    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        audio1 = gameObject.AddComponent<AudioSource>();
		audio1.clip = audioclip1;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Jump "+isJump);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }
        Move();
        Dead();
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        if (isJump)
        {
            anim.ResetTrigger("Jump");
            if (idMove == 0) anim.SetTrigger("Idle");
            isJump = false;
        }
 
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        anim.SetTrigger("Jump");
        anim.ResetTrigger("Run");
        anim.ResetTrigger("Idle");
        isJump = true;
    }
    
    public void MoveRight()
    {
        idMove = 1;
    }
    
    public void MoveLeft()
    {
        idMove = 2;
    }
    
    private void Move()
    {
        if (idMove == 1 && !isDead)
        {
            // Kondisi ketika bergerak ke kekanan
            if (!isJump) anim.SetTrigger("Run");
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        if (idMove == 2 && !isDead)
        {
            // Kondisi ketika bergerak ke kiri
            if (!isJump) anim.SetTrigger("Run");
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
    }
    
    public void Jump()
    {
        if (!isJump)
        {
            // Kondisi ketika Loncat           
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Coin"))
        {
            Data.score += 15;
            Destroy(collision.gameObject);
            audio1.Play();
        }
    }
    
    public void Idle()
    {
        // kondisi ketika idle/diam
        if (!isJump)
        {
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("Run");
            anim.SetTrigger("Idle");
        }
        idMove = 0;
    }
    
    private void Dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {
                // kondisi ketika jatuh
                isDead = true;
            }
        }
    }

}
