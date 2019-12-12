using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goutte : MonoBehaviour
{
    public Vector3 velocity;
    public float force;
    public GameObject tache;
    public Vector3 position;
    public Vector3 col;
    private Vector3 r;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        position.y += 2f;
        transform.position = position;
        float randx = Random.Range(-50f, 50f);
        float randz = Random.Range(-20f, 20f);
        velocity.x = randx;
        velocity.z = randz;
        GetComponent<Rigidbody>().AddForce(velocity*force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "murg")
        {
            col = collision.contacts[0].point;
            col.z += 0.1f;
            GameObject t = Instantiate(tache, col,Quaternion.Euler(0,90,0));
            t.GetComponent<BoxCollider>().isTrigger = true;
            col = t.transform.position;
            col.x += 0.1f;
            t.transform.position=col;

        }
        else if (collision.collider.tag == "murd")
        {
            col = collision.contacts[0].point;
            col.z += 0.1f;
            GameObject t = Instantiate(tache, col, Quaternion.Euler(0, 90, 0));
            t.GetComponent<BoxCollider>().isTrigger = true;
            col = t.transform.position;
            col.x -= 0.1f;
            t.transform.position = col;

        }
        else
        {
            col = collision.contacts[0].point;
            col.y += 0.1f;
            GameObject t = Instantiate(tache, col, tache.transform.rotation);
            t.GetComponent<BoxCollider>().isTrigger = true; 

        }
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<MeshRenderer>());
        Destroy(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
