using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[RequireComponent(typeof(CharacterController))]
public class Boucher : Ennemi
{

    
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        cri = GetComponent<AudioSource>();
        vie = 100;
        controller = GetComponent<CharacterController>();
        sens = -1;

    }


    void OnTriggerEnter(Collider other)
    {





        if ((other.gameObject.tag == "murg") || (other.gameObject.tag == "murd"))
        {
            sens = sens * (-1);
            sprite.GetComponent<SpriteRenderer>().flipX=!sprite.GetComponent<SpriteRenderer>().flipX;
            mouvement.x = 2 * sens * speed;
        }



    }
    // Update is called once per frame
    void Update()
    {

     mouvement.x = sens * speed;
     mouvement.y -= gravity*Time.deltaTime;
    if (controller.isGrounded)
        {
            mouvement.y = 0;
        }
        controller.Move(mouvement * Time.deltaTime);
    }


}

