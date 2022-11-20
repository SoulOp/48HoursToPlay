using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    public float animationSpeed;
    public float startTime;
    private int bullet = 1;
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
        if(Time.time > startTime+animationSpeed){
            startTime = Time.time;
            bullet+=1;
            bullet%=2;
            bool band = bullet!=0;
            Animator.SetBool("Bullet",band);

        }
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = Vector2.right * Speed;
    }

}
