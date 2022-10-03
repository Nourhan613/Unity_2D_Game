using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class movements : MonoBehaviour
{
    public float direction;
    public int speed = 5;
    public int jumpSpeed = 10;
    public bool isJumping = false;
    public Animator animator;
    private int score = 0;
    // Start is called before the first frame update

    void Start()
    {
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
        if(isJumping == false)
            {
                
                animator.SetBool("jump", false);
            }
            else animator.SetBool("jump", true);
        // Motion in X axis
        if(direction == 0)
        {
            animator.SetBool("run", false);
        }
        else if(direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("run", true);
        } 
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("run", true);
        }
        // Motion in Y axis
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isJumping == false)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * jumpSpeed);
                
            }
            
        }
        Debug.Log("Score: " + score);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isJumping = false;
        }
        if(collision.gameObject.tag == "Melon")
        {
            score +=1 ;
            DestroyObject(collision.gameObject);
        }
        if(collision.gameObject.tag == "spike")
        {
            score = 0 ;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "fire")
        {
            score = 0 ;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "End")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
        else if(collision.gameObject.tag == "spike" || collision.gameObject.tag == "fire"){
        SceneManager.LoadScene(1);
    }

    }
     void OnCollisionExit2D(Collision2D collision2)
    {
        if(collision2.gameObject.tag == "ground")
        {
            isJumping = true;
        }
    }
}
