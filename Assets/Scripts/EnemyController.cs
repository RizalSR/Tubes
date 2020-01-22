using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isGrounded = false; // untuk mengecek karakter berada di ground
	public bool isFacingRight = false;
    public Transform batas1; //digunakan untuk batas gerak ke kiri
	public Transform batas2; // digunakan untuk batas gerak ke kanan	 
	float speed = 2; // kecepatan enemy bergerak


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update(){
    if (isGrounded) 
        {
            if (isFacingRight)
                MoveRight ();
            else
                MoveLeft ();
            if (transform.position.x >= batas2.position.x && isFacingRight)
                Flip();
            else if (transform.position.x <= batas1.position.x && !isFacingRight)
                Flip ();
        }
    }
    void MoveRight()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (!isFacingRight)
        {
            Flip();
        }
    }
    void MoveLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
        if (isFacingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingRight = !isFacingRight;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    //digunakan untuk mengecek apakah Player masih diatas tanah atau tidak
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    //digunakan untuk memberi tahu Player bahwa sudah tidak diatas tanah
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
