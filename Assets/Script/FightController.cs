using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    private int sens;
    public GameObject supervegan;
    public Ennemi[] ennemis;
    private BoxCollider veganBox;
    private Vector3 boxSize;
    private Vector3 centerBox;
    // Start is called before the first frame update
    void Start()
    {
        sens = 1;
        veganBox = supervegan.GetComponent<BoxCollider>();
        boxSize = veganBox.size;
        centerBox = veganBox.center;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MooveBox()
    {
        centerBox.z = 100;
        veganBox.center = centerBox;

    }
    public void CoupdeVegan()
    {

        sens = supervegan.GetComponent<SuperVegan>().Getsens();
        boxSize.x = 2f;
        veganBox.size = boxSize;
        centerBox.x = sens*0.8f;
        centerBox.z = 0;
        veganBox.center = centerBox;
        

       /* foreach (Ennemi enem in ennemis)
        {
            

            if (Mathf.Abs(enem.transform.position.y - supervegan.transform.position.y) > 1)
            {
                continue;
            }
            float distance = sens*(enem.transform.position.x - supervegan.transform.position.x);
            // Debug.Log(distance);
            if ((-1 < distance) & (distance < 7))
            {
                enem.PrendunCoup();
            }



        }*/

    }

    public void KickdeVegan()
    {
        boxSize.x = 1.6f;
        centerBox.z = 0;
        veganBox.size = boxSize;
        sens = supervegan.GetComponent<SuperVegan>().Getsens();
        if (sens == -1)
        {
            centerBox.x = 0;
        }
        else
        {
            centerBox.x = 0.38f;
        }
        veganBox.center = centerBox;
 /*       foreach (Ennemi enem in ennemis)
        {

            if (Mathf.Abs(enem.transform.position.y - supervegan.transform.position.y) > 1)
            {
                continue;
            }
            float distance = sens * (enem.transform.position.x - supervegan.transform.position.x);
            // Debug.Log(distance);
            if ((-1 < distance) & (distance < 5))
            {
                enem.PrendunCoup();
            }



        }
*/
    }
}
