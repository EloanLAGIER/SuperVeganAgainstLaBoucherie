using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public GameObject boucher;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
        {
            time = 0;
            Instantiate(boucher, transform.position, Quaternion.identity);
        }
    }
}
