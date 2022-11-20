using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    

    public GameObject Bullet;

    //movement
    public float horizontal;
    public float vertical;
    
    //Velocity
    public float xVelocity;
    public float yVelocity;

    //Jump
    public float jumpForce;
    public float jumpCD;
    private float JumpTimeStart=0;
    
    //animation
    private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();    
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move w,a,s,d
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        //animation
        Animator.SetInteger("direction",(int)vertical);

        
        //jump
        if(Input.GetKeyDown("space") & cd_met(JumpTimeStart,jumpCD))
            {
              Jump();  
            }

        if(Input.GetKeyDown(KeyCode.X)){
            Shoot();
        }
    }
    
    private void Shoot(){
        GameObject bullet = Instantiate(Bullet, transform.position,Quaternion.identity);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal*xVelocity,vertical*yVelocity);
        
    }

    //player functions
    void Jump()
    {
        JumpTimeStart = Time.time;
                if (vertical == -1)
                    {
                        Rigidbody2D.AddForce(Vector2.down*jumpForce);
                    }
                else
                    {
                        Rigidbody2D.AddForce(Vector2.up*jumpForce);
                    }   
    }

    bool cd_met(float skill_start,float skill_cd)
    {
        return (Time.time > skill_start+skill_cd);       
    }

}
