using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SuperVegan : MonoBehaviour
{
    public float speed, jumpSpeed, gravity;
    private Vector3 mouvement;
    private Vector3 centerBox;
    private CharacterController controller;
    private int jumpcount;
    private Ray hitray;
    private RaycastHit hit;
    public GameObject ennemi;
    public GameObject sprit;
    private Animator anim;
    private float time;
    private BoxCollider box;
    private float sens;
    private float timecour;
    private AudioSource sv;
    public AudioClip cour;
    public AudioClip saut;
    public AudioClip coup;
    private float timercoup;
    // Start is called before the first frame update
    void Awake()
    {
        sv = GetComponent<AudioSource>();
        sens = 0;
        ennemi = null;
        anim = sprit.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        box = GetComponent<BoxCollider>();
        hitray = new Ray(transform.position, new Vector3(15f, 0.0f, 0.0f));
        centerBox = box.center;
        timercoup = 3;
    }

    void OnTriggerEnter(Collider other)
    {


        ennemi = other.gameObject;
        if (other.gameObject.name == "Boucher")
        {
            ennemi = other.gameObject;


        }


    }

    private void OnTriggerExit(Collider other)
    {
        ennemi = null;
    }
    void Update()
    {
        timercoup += Time.deltaTime;

        mouvement.x = Input.GetAxisRaw("Horizontal") * speed;
        hitray = new Ray(transform.position, new Vector3(mouvement.x, 0.0f, 0.0f));
        mouvement.y -= gravity * Time.deltaTime;
        if ((Input.GetButtonDown("Fire1")) & (timercoup > 1.2) & (Input.GetAxisRaw("Horizontal")!=0)&(controller.isGrounded))
        {
            timercoup = 0;
            anim.SetTrigger("c");
            sv.loop = false;
            sv.clip = coup;
            sv.Play();
            if (ennemi != null)
            {
                ennemi.GetComponent<Boucher>().PrendunCoup();
            }

        }
        if (controller.isGrounded)
        {
            anim.SetTrigger("sol");
            mouvement.y = 0;
            jumpcount = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((sv.loop == false) & (controller.isGrounded) & (timercoup>1.2))
            {
                sv.clip = cour;
                sv.Play();
                sv.loop = true;
                
                
            }
            time = 0f;

            anim.SetTrigger("d");
            centerBox.x = 2;
            box.center = centerBox;


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if ((sv.loop == false)& (controller.isGrounded) & (timercoup > 1.2))
            {
                sv.clip = cour;
                sv.Play();
                sv.loop = true;
                
            }
            time = 0f;
            
            
            anim.SetTrigger("g");
            
            centerBox.x = -2;
            box.center = centerBox;

        }
        if (mouvement.x==0)
        {

            if((controller.isGrounded) & (timercoup > 1.2))
            {
                Debug.Log(time);
                time = 0f;
                sv.Stop();
                sv.loop = false;
                
                anim.SetTrigger("r");
            }
        }
    
        if (Input.GetButtonDown("Jump") && (jumpcount<3) & (timercoup > 1.2))
        {
            sv.loop = false;
            sv.clip = saut;
            sv.Play();
            mouvement.y = jumpSpeed;
            anim.SetTrigger("s");
            
            jumpcount+=1; 
        }
        controller.Move(mouvement * Time.deltaTime);
        Debug.DrawRay(transform.position, hitray.direction, Color.green);
      /*  if (Input.GetButtonDown("Fire1"))
        {


            if (Physics.Raycast(hitray, out hit))
            {
                if (hit.rigidbody != null)
                {

                    mouvement.y = jumpSpeed;

                }
            }
            
        }*/
        
    }
}
