using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[RequireComponent(typeof(CharacterController))]
public class Boucher : MonoBehaviour
{
    public float speed, jumpSpeed, gravity;
    public Vector3 mouvement;
    private CharacterController controller;
    private int jumpcount;
    public int sens;
    private bool drap;
    public float time;
    public Collider c;
    public Goutte goutte;
    public GameObject sprite;
    public int vie;
    private AudioSource cri;
    public AudioClip cri1;
    public AudioClip cri2;
    public AudioClip dead;
    // Start is called before the first frame update
    void Awake()
    {
        cri = GetComponent<AudioSource>();
        vie = 100;
        controller = GetComponent<CharacterController>();
        sens = -1;

    }
    public void Mort()
    {
        cri.clip = dead;
        cri.Play();
        Destroy(sprite.GetComponent<SpriteRenderer>());
        for (int i = 0; i < 30; i++)
        {
            Goutte g = Instantiate(goutte, transform.position, Quaternion.identity);
            float sc_goute = Random.Range(0.5f, 1.2f);
            g.transform.localScale = new Vector3(sc_goute, sc_goute, sc_goute);
            g.GetComponent<Rigidbody>().mass = 15;
        }
        Destroy(this);
    }
    public void PrendunCoup() {
        /*        if (dead == false)
                {
                    dead = true;*/
        
        vie -= Random.Range(0, 20);
        if (vie <= 0)
        {
            this.Mort();
            return;
        }
            int rs = Random.Range(0, 2);
            if (rs == 0)
            {
                cri.clip = cri1;
            }
            else
            {
                cri.clip = cri2;
            }
            cri.Play();
            int nbr_goute = Random.Range(1, 5);
            for (int i = 0; i < nbr_goute; i++)
            {
                Goutte g = Instantiate(goutte, transform.position, Quaternion.identity);
                float sc_goute = Random.Range(0.1f, 0.65f);
                g.transform.localScale = new Vector3(sc_goute, sc_goute, sc_goute);
            }
            mouvement.y = jumpSpeed;
            controller.Move(mouvement * Time.deltaTime);

        /*            mouvement.x = 0;

                    time = Time.deltaTime;
                }*/
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
            jumpcount = 0;
        }
        controller.Move(mouvement * Time.deltaTime);
    }


}

