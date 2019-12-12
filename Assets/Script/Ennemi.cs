using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public int vie;
    protected AudioSource cri;
    public AudioClip cri1;
    public AudioClip cri2;
    public AudioClip dead;
    public GameObject sprite;
    public Goutte goutte;
    public float speed, jumpSpeed, gravity;
    public Vector3 mouvement;
    protected CharacterController controller;
    public int sens;
    protected bool drap;
    public float time;
    public Collider c;

    public void Mort()
    {
        cri.clip = dead;
        cri.Play();
        Destroy(sprite.GetComponent<SpriteRenderer>());
        for (int i = 0; i < 30; i++)
        {
            Vector3 np = transform.position;
            np.y += 2;
            Goutte g = Instantiate(goutte, np, Quaternion.identity);
            float sc_goute = Random.Range(0.5f, 1.2f);
            g.transform.localScale = new Vector3(sc_goute, sc_goute, sc_goute);
            g.GetComponent<Rigidbody>().mass = 15;
        }
        Destroy(this);
    }
    public void PrendunCoup()
    {
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
            Vector3 np = transform.position;
            np.y += 2;
            Goutte g = Instantiate(goutte, np, Quaternion.identity);
            float sc_goute = Random.Range(0.1f, 0.65f);
            g.transform.localScale = new Vector3(sc_goute, sc_goute, sc_goute);
        }
        mouvement.y = jumpSpeed;
        controller.Move(mouvement * Time.deltaTime);

        /*            mouvement.x = 0;

                    time = Time.deltaTime;
                }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
