using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SuperVegan : MonoBehaviour
{
    public float speed, jumpSpeed, gravity;
    private Vector3 mouvement;
    
    private CharacterController controller;
    private int jumpcount;
    public Ennemi ennemi;
    private Animator anim;
    private float time;

    private int sens;
    private float timercoup;
    // Start is called before the first frame update
    void Awake()
    {
        
        sens = 1;
        ennemi = null;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        
        timercoup = 3;
    }

    public int Getsens()
    {
        return sens;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.GetComponent<Ennemi>())
        {
            collision.gameObject.GetComponent<Ennemi>().PrendunCoup();
        }
    }


    void Update()
    {



        mouvement.x = Input.GetAxisRaw("Horizontal") * speed;
        mouvement.y -= gravity * Time.deltaTime;
        if ((Input.GetButtonDown("Fire1")) )
        {
            timercoup = 0;
            anim.SetTrigger("coup");


        }
        if (controller.isGrounded)
        {
            anim.SetBool("saut", false);
            mouvement.y = 0;
            jumpcount = 0;
        }
        if (Input.GetAxisRaw("Horizontal")>0)
        {
            
            time = 0f;
            
            anim.SetBool("droite", true);
            anim.SetBool("gauche", false);
            anim.SetBool("repos", false);
            anim.SetBool("sens", true);
            sens = 1;
            

        }
         if (Input.GetAxisRaw("Horizontal")<0)
        {


            time = 0f;
            anim.SetBool("sens", false);
            anim.SetBool("droite", false);
            anim.SetBool("gauche", true);
            anim.SetBool("repos", false);
            sens = -1;
            
            

        }
        if(Input.GetAxisRaw("Horizontal")==0)
        {
            time += Time.deltaTime;
            if( (time > 0.2f)&(controller.isGrounded))
            {
                anim.SetBool("droite", false);
                anim.SetBool("gauche", false);
                anim.SetBool("repos", true);
                
                
            }
        }
    
        if (Input.GetButtonDown("Jump") && (jumpcount<3))
        {
            
            mouvement.y = jumpSpeed;
            anim.SetBool("saut", true);
            
            jumpcount+=1; 
        }
        controller.Move(mouvement * Time.deltaTime);


        
    }
}
