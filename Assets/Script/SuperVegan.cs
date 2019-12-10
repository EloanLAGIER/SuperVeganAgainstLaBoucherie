using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SuperVegan : MonoBehaviour
{
    public float speed,jumpSpeed,gravity;
    private Vector3 mouvement;
    private Vector3 centerBox;
    private CharacterController controller;
    private int jumpcount;
    private Ray hitray;
    private RaycastHit hit;
    private GameObject ennemi;
    public GameObject sprite;

    private BoxCollider box;
    // Start is called before the first frame update
    void Awake()
    {
        ennemi = null;
        controller = GetComponent<CharacterController>();
        box = GetComponent<BoxCollider>();
        hitray = new Ray(transform.position, new Vector3(15f, 0.0f, 0.0f));
        centerBox = box.center;
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

        mouvement.x = Input.GetAxisRaw("Horizontal")*speed;
        hitray = new Ray(transform.position, new Vector3(mouvement.x, 0.0f, 0.0f));
        mouvement.y -= gravity *Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if (ennemi != null)
            {
                ennemi.GetComponent<Boucher>().PrendunCoup();
            }

        }
        if (controller.isGrounded)
        {
            mouvement.y = 0;
            jumpcount = 0;
        }
        if (Input.GetAxisRaw("Horizontal")>0)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = false;
            centerBox.x = 2;
            box.center= centerBox;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = true;
            centerBox.x = -2;
            box.center = centerBox;
        }
        if (Input.GetButtonDown("Jump") && (jumpcount<3)){
            mouvement.y = jumpSpeed;
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
